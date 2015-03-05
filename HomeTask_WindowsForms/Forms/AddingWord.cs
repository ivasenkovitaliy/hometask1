using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class AddingWord : Form
    {
        private readonly WordRepository _wordRepository = new WordRepository();
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
            
            bindingSourceComboCoxCategory.DataSource = LocalAppData.Categories;
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

            // if there are no empty fields then adding word....
            if (panel1.Controls.OfType<TextBox>().FirstOrDefault(r => r.BackColor == color) == null)
            {
                var newWordId = _wordRepository.AddWord(new Word(textBoxOriginal.Text, textBoxRU1.Text, textBoxRU2.Text, textBoxRU3.Text, (int)comboBoxCategories.SelectedValue));
                LocalAppData.Words.Add(new Word(newWordId, textBoxOriginal.Text, textBoxRU1.Text, textBoxRU2.Text, textBoxRU3.Text, (int)comboBoxCategories.SelectedValue, comboBoxCategories.Text));

                PrepareForm();
            }
        }
    }
}
