using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace HomeTask_WindowsForms
{
    public partial class UpdatingWord : Form
    {
        private readonly Word _updatingWord;
        private readonly WordRepository _wordRepository = new WordRepository();
        
        public UpdatingWord(Word updatingWord)
        {
            InitializeComponent();
            _updatingWord = updatingWord;

            // filling up boxes on form
            textBoxOriginal.Text = updatingWord.Original;

            bindingSourceComboBoxCategories.DataSource = LocalAppData.Categories;
            comboBoxCategories.Text = updatingWord.Category;

            textBoxRU1.Text = updatingWord.Translate;

            if ( !updatingWord.TranslateSecond.Equals(string.Empty))
            {
                textBoxRU2.Enabled = true;
                textBoxRU2.Text = updatingWord.TranslateSecond;
            }

            if ( !updatingWord.TranslateThird.Equals(string.Empty))
            {
                textBoxRU3.Enabled = true;
                textBoxRU3.Text = updatingWord.TranslateThird;
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
                _wordRepository.UpdateWord(_updatingWord.Id, new Word(textBoxOriginal.Text, textBoxRU1.Text, textBoxRU2.Text, textBoxRU3.Text), (int) comboBoxCategories.SelectedValue);
                
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
