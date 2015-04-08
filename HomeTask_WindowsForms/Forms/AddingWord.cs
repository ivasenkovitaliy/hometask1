using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EnglishAssistant.DAL;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;
using EnglishAssistant.Infrastructure.Extensions;

namespace EnglishAssistant.Forms
{
    public partial class AddingWord : Form
    {
        private readonly WordRepository _wordRepository = new WordRepository();
        private readonly ITranslator _translator;

        public AddingWord()
        {
            InitializeComponent();
            PrepareForm();

            _translator = new YandexTranslator(Properties.Settings.Default.YandexTranslatorApiKey, new XmlWebRequester());
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
            
            bindingSourceComboCoxCategory.DataSource = LocalAppData.Instance.Categories;
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
                var allWords = LocalAppData.Instance.Words;
                if (allWords.Any(x => x.Original.IsSame(textBoxOriginal.Text)))
                {
                    MessageBox.Show("This word is already added to your vocabulary.");
                    return;
                }

                var addingWord = new Word(textBoxOriginal.Text, textBoxRU1.Text, textBoxRU2.Text, textBoxRU3.Text,
                    (int) comboBoxCategories.SelectedValue);

                _wordRepository.AddWord(addingWord);
                LocalAppData.Instance.Words.Add(addingWord);

                PrepareForm();
            }
        }

        private void GetTranslation(object sender, KeyEventArgs e)
        {
            string fromLanguage = string.Empty;
            string toLanguage = string.Empty;

            var textBox = (TextBox)sender;
            var textBoxToInsertText = new TextBox();

            if (textBox.Name == textBoxOriginal.Name)
            {
                fromLanguage = "en";
                toLanguage = "ru";
                textBoxToInsertText = textBoxRU1;
            }
            else if (textBox.Name == textBoxRU1.Name)
            {
                fromLanguage = "ru";
                toLanguage = "en";
                textBoxToInsertText = textBoxOriginal;
            }

            var translation = _translator.GetTranslation(textBox.Text, fromLanguage, toLanguage);
            textBoxToInsertText.Text = translation;
        }
    }
}
