using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class CategoriesManagement : Form
    {
        readonly private DBRepository _repository = new DBRepository();
        public CategoriesManagement()
        {
            InitializeComponent();
            PrepareForm();
            
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

            // filling up table
            foreach (var category in LocalRepository.Categories)
            {
                int tempCount = 0;
                foreach (var word in LocalRepository.Words)
                {
                    if (word.Category == category.CategoryName)
                        tempCount++;
                }
                dataGridViewCategoriesManagement.Rows.Add(category.CategoryName, tempCount);
            }

            dataGridViewCategoriesManagement.ClearSelection(); // remove selection from first row
            //throw new NotImplementedException();
        }
        private void PrepareForm()
        {
            buttonUpdateCategory.Enabled = false;
            buttonDeleteCategory.Enabled = false;
            textBoxNewCategoryName.Text = "enter new category/category name name here";
            textBoxNewCategoryName.ForeColor = Color.Gray;
            DrawTable();
        }

        private string GetActiveCategoryName()
        {
            return dataGridViewCategoriesManagement.CurrentRow.Cells[0].Value.ToString();
        }

        private int GetActiveCategoryIndex()
        {
            return dataGridViewCategoriesManagement.CurrentRow.Index;
        }

        void dataGridViewCategoriesManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
        
        void WordsManagment_Closing(object sender, CancelEventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Start();
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
                LocalRepository.Categories.Add(new Category(textBoxNewCategoryName.Text.Trim(), false));
                _repository.AddCategory(textBoxNewCategoryName.Text.Trim());
                PrepareForm();
            }
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            _repository.RemoveCategory(GetActiveCategoryName());
            LocalRepository.Categories.Remove(LocalRepository.Categories.ElementAt(GetActiveCategoryIndex()));
            PrepareForm();
        }

        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (!textBoxNewCategoryName.Text.Equals("") && !textBoxNewCategoryName.Text.Equals(" ") &&
                !textBoxNewCategoryName.Text.Equals("enter new category/category name name here"))
            {
                _repository.UpdateCategory(GetActiveCategoryName(), textBoxNewCategoryName.Text);
                var temp = LocalRepository.Categories.ElementAt(GetActiveCategoryIndex());
                LocalRepository.Categories.Remove(temp);
                temp.CategoryName = textBoxNewCategoryName.Text;
                LocalRepository.Categories.Add(temp);
                
                // updating "category" fiels in wors list 
                foreach (var word in LocalRepository.Words)
                {
                    if (word.Category.Equals(GetActiveCategoryName()))
                        word.Category = textBoxNewCategoryName.Text;
                }
                PrepareForm();
            }
        }
    }
}
