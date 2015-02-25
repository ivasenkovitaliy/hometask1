using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class WordsManagement : Form
    {
        readonly private CategoryRepository _categoryRepository = new CategoryRepository();
        readonly private WordRepository _wordRepository = new WordRepository();
        public WordsManagement()
        {
            InitializeComponent();

            PrepareForm();

            this.FormClosing += WordsManagement_FormClosing;
            this.textBoxWordForSearching.GotFocus += textBoxWordForSearching_GotFocus;
            this.dataGridViewWordsManagement.CellClick += dataGridViewWordsManagement_CellClick;
            this.Activated += WordsManagement_Activated;
            this.dataGridViewWordsManagement.RowPostPaint += dataGridViewWordsManagement_RowPostPaint;
        }

        void dataGridViewWordsManagement_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridViewWordsManagement.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            //throw new NotImplementedException();
        }

        void WordsManagement_Activated(object sender, EventArgs e)
        {
            PrepareForm();
            //throw new NotImplementedException();
        }

        private void PrepareForm()
        {
            // asking new lists
            LocalAppData.Categories = _categoryRepository.GetAllCategories().ToList();
            LocalAppData.Words = _wordRepository.GetAllWords().ToList();
            
            //preparing combobox of categories
            bindingSourceComboBoxCategories.DataSource = LocalAppData.Categories;

            buttonDeleteWord.Enabled = false;
            buttonEditWord.Enabled = false;
            
            textBoxWordForSearching.Text = "search";
            textBoxWordForSearching.ForeColor = Color.Gray;
            
            DrawTable(LocalAppData.Words);
        }

        private void DrawTable(IEnumerable<Word> wordsToFillTable)
        {
            bindingSourceWordsManagement.DataSource = wordsToFillTable;
            //throw new NotImplementedException();
        }

        void dataGridViewWordsManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDeleteWord.Enabled = true;
            buttonEditWord.Enabled = true;
            //throw new NotImplementedException();
        }

        void textBoxWordForSearching_GotFocus(object sender, EventArgs e)
        {
            textBoxWordForSearching.Text = "";
            textBoxWordForSearching.ForeColor = Color.Black;
            //throw new NotImplementedException();
        }
        
        void WordsManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalAppData.TimerForShowingTestWindow.Start();
            //throw new NotImplementedException();
        }

        private void buttonFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var filteredWords =
                from word in LocalAppData.Words
                where
                    textBoxWordForSearching.Text.Equals(word.Original)
                    && comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
                select word;

            DrawTable(filteredWords);
        }

        private void comboBoxSelectCategoryForSearching_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wordsSelectedWithCategory =
                from word in LocalAppData.Words
                where comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
                select word;
         
            DrawTable(wordsSelectedWithCategory);
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            AddingWord form = new AddingWord();

            form.Show();
        }

        private void buttonDeleteWord_Click(object sender, EventArgs e)
        {
            _wordRepository.RemoveWord( (Word) dataGridViewWordsManagement.CurrentRow.DataBoundItem);
            
            PrepareForm();
        }

        private void buttonEditWord_Click(object sender, EventArgs e)
        {
            UpdatingWord form = new UpdatingWord((Word) dataGridViewWordsManagement.CurrentRow.DataBoundItem);

            form.Show();
        }
    }
}
