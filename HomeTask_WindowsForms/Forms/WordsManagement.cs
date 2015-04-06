using HomeTask_WindowsForms.DAL;
using HomeTask_WindowsForms.Entities;
using HomeTask_WindowsForms.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HomeTask_WindowsForms.Infrastructure.Extensions;

namespace HomeTask_WindowsForms.Forms
{
    public partial class WordsManagement : Form
    {
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
        }

        void WordsManagement_Activated(object sender, EventArgs e)
        {
            PrepareForm();
        }

        private void PrepareForm()
        {
            //preparing combobox of categories
            bindingSourceComboBoxCategories.DataSource = LocalAppData.Instance.Categories;

            buttonDeleteWord.Enabled = false;
            buttonEditWord.Enabled = false;

            textBoxWordForSearching.Text = "search";
            textBoxWordForSearching.ForeColor = Color.Gray;

            DrawTable(LocalAppData.Instance.Words);
        }

        private void DrawTable(IEnumerable<Word> wordsToFillTable)
        {
            bindingSourceWordsManagement.ResetBindings(true);
            bindingSourceWordsManagement.DataSource = wordsToFillTable;
        }

        void dataGridViewWordsManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDeleteWord.Enabled = true;
            buttonEditWord.Enabled = true;
        }

        void textBoxWordForSearching_GotFocus(object sender, EventArgs e)
        {
            textBoxWordForSearching.Text = "";
            textBoxWordForSearching.ForeColor = Color.Black;
        }

        void WordsManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Start();
        }

        private void buttonFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var allWords = LocalAppData.Instance.Words;
            var searchingValue = textBoxWordForSearching.Text;

            if (string.IsNullOrEmpty(searchingValue) || string.IsNullOrWhiteSpace(searchingValue))
                DrawTable(allWords);

            var filteredWords = allWords.Where(x => x.IsOriginalOrTranslation(searchingValue) &&
                string.Equals(x.Category, comboBoxSelectCategoryForSearching.Text)
                );

            if (checkShowOnlyLearnedWords.Checked)
                filteredWords = filteredWords.Where(x => x.IsLearnedRussian && x.IsLearnedEnglish);

            DrawTable(filteredWords);
        }

        private void comboBoxSelectCategoryForSearching_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wordsSelectedWithCategory =
                from word in LocalAppData.Instance.Words
                where comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
                select word;

            if (checkShowOnlyLearnedWords.Checked)
                wordsSelectedWithCategory = wordsSelectedWithCategory.Where(x => x.IsLearnedRussian && x.IsLearnedEnglish);

            DrawTable(wordsSelectedWithCategory);
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            var form = new AddingWord();
            form.Show();
        }

        private void buttonDeleteWord_Click(object sender, EventArgs e)
        {
            if (dataGridViewWordsManagement.CurrentRow != null)
            {
                var deletingWord = (Word)dataGridViewWordsManagement.CurrentRow.DataBoundItem;

                _wordRepository.RemoveWord(deletingWord);
                LocalAppData.Instance.Words.Remove(deletingWord);
            }

            PrepareForm();
        }

        private void buttonEditWord_Click(object sender, EventArgs e)
        {
            if (dataGridViewWordsManagement.CurrentRow != null)
            {
                var form = new UpdatingWord((Word)dataGridViewWordsManagement.CurrentRow.DataBoundItem);
                form.Show();
            }
        }

        private void textBoxWordForSearching_KeyPress(object sender, KeyPressEventArgs e)
        {
            buttonFilter_Click(null, null);
        }

        private void checkShowOnlyLearnedWords_CheckedChanged(object sender, EventArgs e)
        {
            var allWords = LocalAppData.Instance.Words;
            if (((CheckBox) sender).Checked)
                allWords = allWords.Where(x => x.IsLearnedRussian && x.IsLearnedEnglish).ToList();

            DrawTable(allWords);
        }
    }
}
