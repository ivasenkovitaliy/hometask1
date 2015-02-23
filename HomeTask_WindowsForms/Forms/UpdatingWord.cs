using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class UpdatingWord : Form
    {
        private readonly Word _updatingWord = new Word();
        private readonly Word _updatedWord = new Word();
        private readonly WordRepository _wordRepository = new WordRepository();
        public UpdatingWord(string updatingWordName)
        {
            InitializeComponent();

            //add empty-field protect!
            LocalAppData.Words = _wordRepository.GetAllWords();
            _updatingWord = LocalAppData.Words.Find(r => r.Original.Equals(updatingWordName));

            // filling up boxes on form
            textBoxOriginal.Text = _updatingWord.Original;

            comboBoxCategories.Text = _updatingWord.Category;
            foreach (var category in LocalAppData.Categories)
            {
                comboBoxCategories.Items.Add(category.CategoryName);
            }

            var updatingWordTranslates = _updatingWord.GetAllTranslatesOfWord();
            textBoxRU1.Text = updatingWordTranslates[0];
            if (updatingWordTranslates.Length == 2)
            {
                textBoxRU2.Enabled = true;
                textBoxRU2.Text = updatingWordTranslates[1];
            }

            else if (updatingWordTranslates.Length == 3)
            {
                textBoxRU3.Enabled = true;
                textBoxRU3.Text = updatingWordTranslates[2];
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            var color = Color.IndianRed;
            foreach (var textBox in panel1.Controls.OfType<TextBox>())
            {
                textBox.BackColor = Color.White;
            }
            foreach (var textBox in panel1.Controls.OfType<TextBox>())
            {
                if (textBox.Enabled && textBox.Text.Equals(""))
                    textBox.BackColor = color;
            }
            
            if (panel1.Controls.OfType<TextBox>().FirstOrDefault(r => r.BackColor == color) == null)
            {
                _updatedWord.Original = textBoxOriginal.Text;
                _updatedWord.Translate = textBoxRU1.Text;
                if (textBoxRU2.Enabled)
                    _updatedWord.Translate += "_" + textBoxRU2.Text;
                if (textBoxRU3.Enabled)
                    _updatedWord.Translate += "_" + textBoxRU3.Text;

                var updatedWordCategory = LocalAppData.GetCategoryWithCategoryName(comboBoxCategories.Text);
                
                _wordRepository.UpdateWord(_updatingWord.Id, _updatedWord.Original, _updatedWord.Translate,
                    updatedWordCategory.CategoryId);
                Close();
            }
        }
        private void buttonAddTranslate_Click(object sender, EventArgs e)
        {
            if (textBoxRU2.Enabled)
                textBoxRU3.Enabled = true;
            textBoxRU2.Enabled = true;
        }
    }
}
