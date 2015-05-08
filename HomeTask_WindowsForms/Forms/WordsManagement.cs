using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EnglishAssistant.DAL;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;
using EnglishAssistant.Infrastructure.Extensions;

namespace EnglishAssistant.Forms
{
    public partial class WordsManagement : Form
    {
        private readonly WordRepository _wordRepository = new WordRepository();
        private readonly LocalAppData _localData = LocalAppData.Instance;

        public WordsManagement()
        {
            InitializeComponent();

            PrepareForm();

            FormClosing += WordsManagement_FormClosing;
            textBoxWordForSearching.GotFocus += textBoxWordForSearching_GotFocus;
            dataGridViewWordsManagement.CellClick += dataGridViewWordsManagement_CellClick;
            Activated += WordsManagement_Activated;
            dataGridViewWordsManagement.RowPostPaint += dataGridViewWordsManagement_RowPostPaint;
        }

        private void InitializeLearnedWordsLabel()
        {
            int totalWordsCount = _localData.Words.Count;
            int learnedWordsCount = _localData.Words.Count(x => x.IsFullyLearned);

            learnedWordsLabel.Text = string.Format("Learned {0} from {1}", learnedWordsCount, totalWordsCount);
        }

        void dataGridViewWordsManagement_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewWordsManagement.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        void WordsManagement_Activated(object sender, EventArgs e)
        {
            PrepareForm();
        }

        private void PrepareForm()
        {
            //preparing combobox of categories
            bindingSourceComboBoxCategories.DataSource = _localData.Categories;

            buttonDeleteWord.Enabled = false;
            buttonEditWord.Enabled = false;

            textBoxWordForSearching.Text = "Search";
            textBoxWordForSearching.ForeColor = Color.Gray;

            DrawTable(_localData.Words);
            InitializeLearnedWordsLabel();
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
            _localData.TimerForShowingTestWindow.Start();
        }

        private void buttonFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var allWords = _localData.Words;
            var searchingValue = textBoxWordForSearching.Text;

            if (string.IsNullOrEmpty(searchingValue) || string.IsNullOrWhiteSpace(searchingValue))
                DrawTable(allWords);

            var filteredWords = allWords.Where(x => x.IsOriginalOrTranslation(searchingValue) &&
                string.Equals(x.Category, comboBoxSelectCategoryForSearching.Text)
                );

            if (checkShowOnlyLearnedWords.Checked)
                filteredWords = filteredWords.Where(x => x.IsFullyLearned);

            DrawTable(filteredWords);
        }

        private void comboBoxSelectCategoryForSearching_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wordsSelectedWithCategory =
                from word in _localData.Words
                where comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
                select word;

            if (checkShowOnlyLearnedWords.Checked)
                wordsSelectedWithCategory = wordsSelectedWithCategory.Where(x => x.IsFullyLearned);

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
                _localData.Words.Remove(deletingWord);
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
            var allWords = _localData.Words;
            if (((CheckBox) sender).Checked)
                allWords = allWords.Where(x => x.IsFullyLearned).ToList();

            DrawTable(allWords);
        }

        private void textBoxWordForSearching_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = string.Empty;
        }

        private void resetLearnedWordsButton_Click(object sender, EventArgs e)
        {
            _wordRepository.ResetAllLearnedWords();
            _localData.Words = _wordRepository.GetAllWords().ToList();
            PrepareForm();
        }
    }
}
