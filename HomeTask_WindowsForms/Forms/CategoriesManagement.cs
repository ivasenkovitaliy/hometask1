using HomeTask_WindowsForms.DAL;
using HomeTask_WindowsForms.Entities;
using HomeTask_WindowsForms.Infrastructure;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HomeTask_WindowsForms.Forms
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

            LocalAppData.Instance.CountWordsInCategories();

            bindingSourceCategoryManagement.ResetBindings(true);
            bindingSourceCategoryManagement.DataSource = LocalAppData.Instance.Categories;
            
            dataGridViewCategoriesManagement.ClearSelection(); // remove selection from first row
            
        }

        void dataGridViewCategoriesManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDeleteCategory.Enabled = true;
            buttonUpdateCategory.Enabled = true;
        }

        void textBoxNewCategoryName_GotFocus(object sender, EventArgs e)
        {
            textBoxNewCategoryName.Text = "";
            textBoxNewCategoryName.ForeColor = Color.Black;
        }

        void WordsManagment_Closing(object sender, CancelEventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Start();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if ( !string.IsNullOrWhiteSpace(textBoxNewCategoryName.Text) &&
                !textBoxNewCategoryName.Text.Equals("enter new category/category name name here"))
            {
                var newCategory = new Category(textBoxNewCategoryName.Text);
                
                _categoryRepository.AddCategory(newCategory);
                LocalAppData.Instance.Categories.Add(newCategory);

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
                LocalAppData.Instance.UpdateCategoryInWordsWhileDeleting(categoryToDelete);

                _categoryRepository.RemoveCategory(categoryToDelete);
                LocalAppData.Instance.Categories.Remove(categoryToDelete);
            }

            PrepareForm();
        }

        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategoriesManagement.CurrentRow != null)
            {
                var categoryToUpdate = (Category) dataGridViewCategoriesManagement.CurrentRow.DataBoundItem;
                
                LocalAppData.Instance.UpdateCategoryInWords(categoryToUpdate);

                _categoryRepository.UpdateCategory(categoryToUpdate);
                LocalAppData.Instance.Categories[LocalAppData.Instance.Categories.IndexOf(categoryToUpdate)] = categoryToUpdate;
            }

            PrepareForm();
        }
    }
}
