using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class AddingWord : Form
    {
        private readonly DBRepository _repository = new DBRepository();
        public AddingWord()
        {
            InitializeComponent();
            PrepareForm();
        }

        private void PrepareForm()
        {
            //cleaning textboxes
            foreach (var textBox in panel1.Controls.OfType<TextBox>())
            {
                textBox.BackColor = Color.White;
                textBox.Text = "";
            }
            textBoxRU2.Enabled = false;
            textBoxRU3.Enabled = false;
            comboBoxCategories.Items.Clear();

            foreach (var category in LocalRepository.Categories)
            {
                comboBoxCategories.Items.Add(category.CategoryName);
            }
            comboBoxCategories.Text = LocalRepository.Categories.First().CategoryName;
            //throw new NotImplementedException();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonAddNewTranslation_Click(object sender, EventArgs e)
        {
            if (textBoxRU2.Enabled)
                textBoxRU3.Enabled = true;
            textBoxRU2.Enabled = true;
        }
        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            // lighting up empty fields
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

            // if there are no empty fields then adding word
            if (panel1.Controls.OfType<TextBox>().FirstOrDefault(r => r.BackColor == color) == null)
            {
                string translation = textBoxRU1.Text;
                if (textBoxRU2.Enabled)
                    translation += "_" + textBoxRU2.Text;
                if (textBoxRU3.Enabled)
                    translation += "_" + textBoxRU3.Text;

                if (LocalRepository.Words.FirstOrDefault(w => w.Original.Equals(textBoxOriginal.Text)) == null)
                {
                    LocalRepository.Words.Add(new Word(textBoxOriginal.Text, translation, comboBoxCategories.Text));
                    // adding word to database
                    _repository.AddWord(textBoxOriginal.Text, translation, comboBoxCategories.Text);
                }
                PrepareForm();
            }
        }
    }
}
