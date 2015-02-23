using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class CategoriesManagement : Form
    {
        readonly private CategoryRepository _categoryRepository = new CategoryRepository();
        readonly private WordRepository _wordRepository = new WordRepository();
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

            bindingSourceCategoryManagement.Clear();
            foreach (var category in LocalAppData.Categories)
            {
                int tempCount = 0;
                foreach (var word in LocalAppData.Words)
                    {
                        if (word.Category == category.CategoryName)
                            tempCount++;
                    }

                category.WordsInCategory = tempCount;
                bindingSourceCategoryManagement.Add(category);
            }

            dataGridViewCategoriesManagement.ClearSelection(); // remove selection from first row
            //throw new NotImplementedException();
        }
        private void PrepareForm()
        {
            // asking new lists
            LocalAppData.Categories = _categoryRepository.GetAllCategories();
            LocalAppData.Words = _wordRepository.GetAllWords();

            buttonUpdateCategory.Enabled = false;
            buttonDeleteCategory.Enabled = false;
            textBoxNewCategoryName.Text = "enter new category/category name name here";
            textBoxNewCategoryName.ForeColor = Color.Gray;

            DrawTable();
        }
        private string GetActiveCategoryNameInTable()
        {
            return dataGridViewCategoriesManagement.CurrentRow.Cells[0].Value.ToString();
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
            LocalAppData.TimerForShowingTestWindow.Start();
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
                _categoryRepository.AddCategory(textBoxNewCategoryName.Text.Trim());
                PrepareForm();
            }
        }
        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            var deletingCategory = LocalAppData.GetCategoryWithCategoryName(GetActiveCategoryNameInTable());

            _wordRepository.UpdateWordsCategory(deletingCategory.CategoryId, 1);
            _categoryRepository.RemoveCategory(deletingCategory.CategoryId);
            
            PrepareForm();
        }
        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (!textBoxNewCategoryName.Text.Equals("") && !textBoxNewCategoryName.Text.Equals(" ") &&
                !textBoxNewCategoryName.Text.Equals("enter new category/category name name here"))
            {
                var updatingCategory = LocalAppData.GetCategoryWithCategoryName(GetActiveCategoryNameInTable()); 
                
                _categoryRepository.UpdateCategory(updatingCategory.CategoryId, textBoxNewCategoryName.Text);
                
                PrepareForm();
            }
        }
    }
}
