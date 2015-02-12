using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class CategoriesManagement : Form
    {
        readonly private MainForm _parentForm;
        readonly private Repository _repository = new Repository();
        private int _activeCategoryIndex;
        private string _activeCategoryName;
        //private Category _activeCategoryInDataGrid;

        public CategoriesManagement(MainForm parentform)
        {
            InitializeComponent();
            _parentForm = parentform;
            DrawTable();
            this.Closing += WordsManagment_Closing;
            this.textBoxNewCategoryName.GotFocus += textBoxNewCategoryName_GotFocus;
            this.dataGridViewCategoriesManagement.CellClick += dataGridViewCategoriesManagement_CellClick;
        }

        private void DrawTable()
        {
            // making first column
            DataGridViewColumn columnCategoryName = new DataGridViewTextBoxColumn();
            {
                columnCategoryName.CellTemplate = new DataGridViewTextBoxCell();
                columnCategoryName.ReadOnly = true;
                columnCategoryName.Width = 217;
                columnCategoryName.HeaderText = "Category";
            }

            // making second column
            DataGridViewColumn columnCount = new DataGridViewColumn();
            {
                columnCount.CellTemplate = new DataGridViewTextBoxCell();
                columnCategoryName.ReadOnly = true;
                columnCount.Width = 80;
                columnCount.HeaderText = "Words in category";
            }

            dataGridViewCategoriesManagement.Rows.Clear();   //  cleaning table
            
            // adding columns
            dataGridViewCategoriesManagement.Columns.Insert(0, columnCount);
            dataGridViewCategoriesManagement.Columns.Insert(0, columnCategoryName);

            foreach (var category in _parentForm.Categories)
            {
                int tempCount = 0;
                foreach (var word in _parentForm.Words)
                {
                    if (word.GetCategory() == category.GetCategory)
                        tempCount++;
                }
                dataGridViewCategoriesManagement.Rows.Add(category.GetCategory, tempCount.ToString());
            }
            dataGridViewCategoriesManagement.ClearSelection();
            //throw new NotImplementedException();
        }

        void dataGridViewCategoriesManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //_activeCategoryInDataGrid = new Category(_parentForm.Categories.ElementAt(e.RowIndex).GetCategory().ToString(), _parentForm.Categories.ElementAt(e.RowIndex).GetCategoryUsed());
            _activeCategoryIndex = e.RowIndex;
            _activeCategoryName = dataGridViewCategoriesManagement.Rows[e.RowIndex].Cells[0].Value.ToString();

            buttonDeleteCategory.Enabled = true;
            buttonUpdateCategory.Enabled = true;
            //throw new NotImplementedException();
        }

        void textBoxNewCategoryName_GotFocus(object sender, EventArgs e)
        {
            textBoxNewCategoryName.Text = "";
            textBoxNewCategoryName.ForeColor = Color.Black;
            //throw new NotImplementedException();
        }

        void dataGridViewCategoriesManagement_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewCategoriesManagement.ClearSelection();
            //throw new NotImplementedException();
        }

        void WordsManagment_Closing(object sender, CancelEventArgs e)
        {
            _parentForm.TimerToShowTestWindow.Start();
            //throw new NotImplementedException();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!textBoxNewCategoryName.Text.Equals("") && !textBoxNewCategoryName.Text.Equals(" ") && !textBoxNewCategoryName.Text.Equals("enter new category/category name name here"))
            {
                _parentForm.Categories.Add(new Category(textBoxNewCategoryName.Text.Trim(), false));
                _repository.AddCategory(textBoxNewCategoryName.Text.Trim());
                PrepareForm();
            }
                
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            _repository.RemoveCategory(_parentForm.Categories.ElementAt(_activeCategoryIndex).GetCategory);
                _parentForm.Categories.Remove(_parentForm.Categories.ElementAt(_activeCategoryIndex));
                PrepareForm();
            
        }

        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (!textBoxNewCategoryName.Text.Equals("") && !textBoxNewCategoryName.Text.Equals(" ") &&
                !textBoxNewCategoryName.Text.Equals("enter new category/category name name here"))
            {
                _repository.UpdateCategory(_activeCategoryName, textBoxNewCategoryName.Text);
                var temp = _parentForm.Categories.ElementAt(_activeCategoryIndex);
                _parentForm.Categories.Remove(temp);
                temp.GetCategory = textBoxNewCategoryName.Text;
                _parentForm.Categories.Add(temp);
                PrepareForm();
            }
        }

        private void PrepareForm()
        {
            buttonUpdateCategory.Enabled = false;
            buttonDeleteCategory.Enabled = false;
            textBoxNewCategoryName.Text = "enter new category/category name name here";
            textBoxNewCategoryName.ForeColor = Color.Gray;
            DrawTable();
        }
    }
}
