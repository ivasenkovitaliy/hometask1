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
            // asking new lists
            LocalAppData.Categories = _categoryRepository.GetAllCategories().ToList();
            LocalAppData.Words = _wordRepository.GetAllWords().ToList();

            buttonUpdateCategory.Enabled = false;
            buttonDeleteCategory.Enabled = false;

            textBoxNewCategoryName.Text = "enter new category name name here";
            textBoxNewCategoryName.ForeColor = Color.Gray;

            DrawTable();
        }
        private void DrawTable()
        {
            LocalAppData.CountWordsInCategories();
            
            bindingSourceCategoryManagement.Clear();
            bindingSourceCategoryManagement.DataSource = LocalAppData.Categories;

            dataGridViewCategoriesManagement.ClearSelection(); // remove selection from first row
            //throw new NotImplementedException();
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
                _categoryRepository.AddCategory(new Category(textBoxNewCategoryName.Text) );

                PrepareForm();
            }
        }
        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            var categoryToDelete = (Category)dataGridViewCategoriesManagement.CurrentRow.DataBoundItem;

            _wordRepository.UpdateWordsCategory(categoryToDelete);   // setting free words category "no category"
            _categoryRepository.RemoveCategory(categoryToDelete);  
            
            PrepareForm();
        }
        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            var categoryToUpdate = (Category) dataGridViewCategoriesManagement.CurrentRow.DataBoundItem;

            _categoryRepository.UpdateCategory(categoryToUpdate);
            
            PrepareForm();
        }
    }
}
