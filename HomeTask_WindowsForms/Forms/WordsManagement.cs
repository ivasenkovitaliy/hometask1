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
            this.dataGridViewWordsManagement.CellDoubleClick += dataGridViewWordsManagement_CellDoubleClick;
            this.dataGridViewWordsManagement.LostFocus += dataGridViewWordsManagement_LostFocus;
            this.Activated += WordsManagement_Activated;
        }

        void WordsManagement_Activated(object sender, EventArgs e)
        {
            PrepareForm();
            //throw new NotImplementedException();
        }

        private void PrepareForm()
        {
            // asking new lists
            LocalAppData.Categories = _categoryRepository.GetAllCategories();
            LocalAppData.Words = _wordRepository.GetAllWords();
            
            //preparing combobox of categories
            comboBoxSelectCategoryForSearching.Items.Clear();

            comboBoxSelectCategoryForSearching.Items.Add("All words");
            foreach (var category in LocalAppData.Categories)
            {
                comboBoxSelectCategoryForSearching.Items.Add(category.CategoryName);
            }

            buttonDeleteWord.Enabled = false;
            buttonEditWord.Enabled = false;
            
            textBoxWordForSearching.Text = "search";
            textBoxWordForSearching.ForeColor = Color.Gray;
            
            DrawTable(LocalAppData.Words);

            
        }
        private void DrawTable(IEnumerable<Word> wordsToFillTable)
        {
            bindingSourceWordsManagement.DataSource = typeof(Word);
            bindingSourceWordsManagement.Clear();
            
            int wordCount = 1; //using to display word's # not from db
            foreach (var word in wordsToFillTable)
            {
                word.Id = wordCount;
                bindingSourceWordsManagement.Add(new Word(wordCount, word.Original, word.Translate+" "+word.TranslateSecond+" "+word.TranslateThird, word.Category));
                wordCount++;
            }

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
        
        void dataGridViewWordsManagement_LostFocus(object sender, EventArgs e)
        {
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
            
            if (!textBoxWordForSearching.Text.Equals("search") ||
                !comboBoxSelectCategoryForSearching.Text.Equals("Select Category"))
            {
                List<Word> searchedList = new List<Word>();
                
                var tempList =
                    from word in LocalAppData.Words
                    where
                        textBoxWordForSearching.Text.Equals(word.Original) 
                        && comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
                    select word;

                foreach (var word in tempList)
                {
                    searchedList.Add(word);
                }

                DrawTable(searchedList);
            }
        }

        private void comboBoxSelectCategoryForSearching_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Word> searchedList = new List<Word>();
            
            if (!comboBoxSelectCategoryForSearching.Text.Equals("All words"))
            {
                var tempList =
                from word in LocalAppData.Words
                where
                    comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
                select word;

                foreach (var word in tempList)
                {
                    searchedList.Add(word);
                }
            }
            else
            {
                searchedList = LocalAppData.Words;
            }

            DrawTable(searchedList);
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            AddingWord form = new AddingWord();
            form.Show();
        }
        private void buttonDeleteWord_Click(object sender, EventArgs e)
        {
            LocalAppData.Words = _wordRepository.GetAllWords(); // for using correct word id
            
            var delettingWord = LocalAppData.Words.Find(r => r.Original.Equals(GetActiveWordName()));
            _wordRepository.RemoveWord(delettingWord.Id);
            
            PrepareForm();
        }
        private string GetActiveWordName()
        {
            return dataGridViewWordsManagement.CurrentRow.Cells[1].Value.ToString();
        }
        private void buttonEditWord_Click(object sender, EventArgs e)
        {
            UpdatingWord form = new UpdatingWord(GetActiveWordName());
            form.Show();
        }
        void dataGridViewWordsManagement_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewWordsManagement.ReadOnly = false;
            //throw new NotImplementedException();
        }
    }
}
