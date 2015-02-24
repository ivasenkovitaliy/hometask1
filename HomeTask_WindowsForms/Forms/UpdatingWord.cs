using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class UpdatingWord : Form
    {
        private readonly Word _updatingWord = new Word();
        private readonly WordRepository _wordRepository = new WordRepository();
        public UpdatingWord(string updatingWordName)
        {
            InitializeComponent();

            LocalAppData.Words = _wordRepository.GetAllWords();
            
            _updatingWord = LocalAppData.Words.Find(r => r.Original.Equals(updatingWordName));

            // filling up boxes on form
            textBoxOriginal.Text = _updatingWord.Original;

            comboBoxCategories.Text = _updatingWord.Category;
            foreach (var category in LocalAppData.Categories)
            {
                comboBoxCategories.Items.Add(category.CategoryName);
            }

            textBoxRU1.Text = _updatingWord.Translate;

            if ( !_updatingWord.TranslateSecond.Equals(string.Empty))
            {
                textBoxRU2.Enabled = true;
                textBoxRU2.Text = _updatingWord.TranslateSecond;
            }

            if ( !_updatingWord.TranslateThird.Equals(string.Empty))
            {
                textBoxRU3.Enabled = true;
                textBoxRU3.Text = _updatingWord.TranslateThird;
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
                _wordRepository.UpdateWord(_updatingWord.Id, textBoxOriginal.Text, textBoxRU1.Text, textBoxRU2.Text, textBoxRU3.Text, LocalAppData.GetCategoryWithCategoryName(comboBoxCategories.Text).CategoryId);
                
                Close();
            }
        }
        private void buttonAddTranslate_Click(object sender, EventArgs e)
        {
            if (textBoxRU2.Enabled)
                textBoxRU3.Enabled = true;
            textBoxRU2.Enabled = true;
        }

        private void buttonRemoveTranslate_Click(object sender, EventArgs e)
        {
            if (textBoxRU3.Enabled)
            {
                textBoxRU3.Text = "";
                textBoxRU3.BackColor = Color.White;
                textBoxRU3.Enabled = false;
            }
            else
            {
                textBoxRU2.Text = "";
                textBoxRU2.BackColor = Color.White;
                textBoxRU2.Enabled = false;
            }
        }
    }
}
