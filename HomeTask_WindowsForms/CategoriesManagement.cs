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

        public CategoriesManagement(MainForm parentform)
        {
            InitializeComponent();
            _parentForm = parentform;

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

            dataGridViewCategoriesManagement.SelectionChanged += dataGridViewCategoriesManagement_SelectionChanged; // using for cleaning cursor in datagridview
            dataGridViewCategoriesManagement.Rows.Clear();   //  cleaning table

            // adding columns
            dataGridViewCategoriesManagement.Columns.Insert(0, columnCount);
            dataGridViewCategoriesManagement.Columns.Insert(0, columnCategoryName);
            
            foreach (var category in parentform.Categories)
            {
                int tempCount = 0;
                foreach (var word in _parentForm.Words)
                {
                    if (word.GetCategory() == category.GetCategory())
                        tempCount++;
                }
                dataGridViewCategoriesManagement.Rows.Add(category.GetCategory(), tempCount.ToString());
            }

            this.Closing += WordsManagment_Closing;
            this.textBoxNewCategoryName.GotFocus += textBoxNewCategoryName_GotFocus;
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
            if (!textBoxNewCategoryName.Text.Equals("") && !textBoxNewCategoryName.Text.Equals(" "))
            {
                _parentForm.Categories.Add(new Category(textBoxNewCategoryName.Text.Trim(), false));
                _repository.AddCategory(textBoxNewCategoryName.Text.Trim());
            }
                
        }
    }
}
