using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class WordsManagement : Form
    {
        readonly private DBRepository _dbRepository = new DBRepository();
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
            //preparing combobox of categories
            comboBoxSelectCategoryForSearching.Items.Clear();
            foreach (var category in LocalRepository.Categories)
            {
                comboBoxSelectCategoryForSearching.Items.Add(category.CategoryName);
            }

            buttonDeleteWord.Enabled = false;
            buttonEditWord.Enabled = false;
            textBoxWordForSearching.Text = "search";
            textBoxWordForSearching.ForeColor = Color.Gray;
            DrawTable(LocalRepository.Words);
        }

        private void DrawTable(List<Word> wordsToFillTable)
        {
            dataGridViewWordsManagement.Columns.Clear();
            dataGridViewWordsManagement.Rows.Clear();   //  cleaning table
            // making first column
            DataGridViewColumn columnCount = new DataGridViewTextBoxColumn();
            {
                columnCount.CellTemplate = new DataGridViewTextBoxCell();
                columnCount.ReadOnly = true;
                columnCount.Width = 50;
                columnCount.HeaderText = "#";
            }

            // making second column
            DataGridViewColumn columnWord = new DataGridViewTextBoxColumn();
            {
                columnWord.CellTemplate = new DataGridViewTextBoxCell();
                columnWord.ReadOnly = false;
                columnWord.Width = 130;
                columnWord.HeaderText = "EN";
            }

            // making third column
            DataGridViewColumn columnTranslate = new DataGridViewTextBoxColumn();
            {
                columnTranslate.CellTemplate = new DataGridViewTextBoxCell();
                columnTranslate.ReadOnly = false;
                columnTranslate.Width = 130;
                columnTranslate.HeaderText = "RU";
            }

            //
            DataGridViewColumn columnCategory = new DataGridViewTextBoxColumn();
            {
                columnCategory.CellTemplate = new DataGridViewTextBoxCell();
                columnCategory.ReadOnly = false;
                columnCategory.Width = 130;
                columnCategory.HeaderText = "Category";
            }

            // adding columns
            dataGridViewWordsManagement.Columns.Insert(0, columnCount);
            dataGridViewWordsManagement.Columns.Insert(1, columnWord);
            dataGridViewWordsManagement.Columns.Insert(2, columnTranslate);
            dataGridViewWordsManagement.Columns.Insert(3, columnCategory);
            
            // filling up table
            int tempCount = 1;
            foreach (var word in wordsToFillTable)
            {
                dataGridViewWordsManagement.Rows.Add(tempCount, word.Original, word.GetAllTranslatesOfWordPreformatted(), word.Category);
                tempCount++;
            }
            
            dataGridViewWordsManagement.ClearSelection(); // remove selection from first row
            dataGridViewWordsManagement.ReadOnly = true;
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
        void textBoxWordForSearching_LostFocus(object sender, EventArgs e)
        {
            textBoxWordForSearching.Text = "search";
            textBoxWordForSearching.ForeColor = Color.Gray;
            //throw new NotImplementedException();
        }
        void dataGridViewWordsManagement_LostFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void WordsManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Start();
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
                    from word in LocalRepository.Words
                    where
                        textBoxWordForSearching.Text.Equals(word.Original)
                        //&& comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
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
            var tempList =
                from word in LocalRepository.Words
                where
                    comboBoxSelectCategoryForSearching.Text.Equals(word.Category)
                select word;

            foreach (var word in tempList)
            {
                searchedList.Add(word);
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
            _dbRepository.RemoveWord(GetActiveWordName());
            LocalRepository.Words.Remove(LocalRepository.Words.ElementAt(GetActiveWordIndex()));
            PrepareForm();
        }

        private string GetActiveWordName()
        {
            return dataGridViewWordsManagement.CurrentRow.Cells[1].Value.ToString();
        }
        private int GetActiveWordIndex()
        {
            return dataGridViewWordsManagement.CurrentRow.Index;
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
