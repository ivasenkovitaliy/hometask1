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

        private void PrepareForm()
        {
            buttonUpdateCategory.Enabled = false;
            buttonDeleteCategory.Enabled = false;

            textBoxNewCategoryName.Text = "enter new category name name here";
            textBoxNewCategoryName.ForeColor = Color.Gray;

            LocalAppData.CountWordsInCategories();

            bindingSourceCategoryManagement.ResetBindings(true);
            bindingSourceCategoryManagement.DataSource = LocalAppData.Categories;
            
            dataGridViewCategoriesManagement.ClearSelection(); // remove selection from first row
            
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
            if (!textBoxNewCategoryName.Text.Equals("") && !textBoxNewCategoryName.Text.Equals(" ") &&
                !textBoxNewCategoryName.Text.Equals("enter new category/category name name here"))
            {
                var newCategory = new Category(textBoxNewCategoryName.Text);
                
                var newCategoryId = _categoryRepository.AddCategory(newCategory);
                
                LocalAppData.Categories.Add(new Category(newCategoryId, newCategory.CategoryName, newCategory.IsUsed));

                PrepareForm();
            }
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategoriesManagement.CurrentRow != null)
            {
                var categoryToDelete = (Category) dataGridViewCategoriesManagement.CurrentRow.DataBoundItem;

                // setting free words category "no category"
                _wordRepository.UpdateWordsCategory(categoryToDelete);
                LocalAppData.UpdateCategoryInWordsWhileDeleting(categoryToDelete);

                _categoryRepository.RemoveCategory(categoryToDelete);
                LocalAppData.Categories.Remove(categoryToDelete);
            }

            PrepareForm();
        }

        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategoriesManagement.CurrentRow != null)
            {
                var categoryToUpdate = (Category) dataGridViewCategoriesManagement.CurrentRow.DataBoundItem;
                var indexOfCategoriesList = LocalAppData.Categories.IndexOf(categoryToUpdate);

                LocalAppData.UpdateCategoryInWords(categoryToUpdate);

                // updating category
                _categoryRepository.UpdateCategory(categoryToUpdate);

                LocalAppData.Categories.RemoveAt(indexOfCategoriesList);
                LocalAppData.Categories.Insert(indexOfCategoriesList, categoryToUpdate);
            }

            PrepareForm();
        }
    }
}
