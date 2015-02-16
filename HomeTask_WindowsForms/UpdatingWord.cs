using System;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class UpdatingWord : Form
    {
        private readonly Word _updatingWord = new Word();
        private readonly Word _updatedWord = new Word();
        private readonly DBRepository _dbRepository = new DBRepository();
        public UpdatingWord(string wordName)
        {
            InitializeComponent();

            _updatingWord = LocalRepository.Words.Find(r => r.Original.Equals(wordName));
            textBoxOriginal.Text = _updatingWord.Original;
            comboBoxCategories.Text = _updatingWord.Category;
            foreach (var category in LocalRepository.Categories)
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
            LocalRepository.Words.Remove(_updatingWord);
            _updatedWord.Original = textBoxOriginal.Text;
            _updatedWord.Category = comboBoxCategories.Text;
            _updatedWord.Translate = textBoxRU1.Text;
            if (textBoxRU2.Enabled)
                _updatedWord.Translate += "_" + textBoxRU2.Text;
            if (textBoxRU3.Enabled)
                _updatedWord.Translate += "_" + textBoxRU3.Text;
            LocalRepository.Words.Add(_updatedWord);
            _dbRepository.UpdateWord(_updatingWord.Original, _updatedWord.Original, _updatedWord.Translate, _updatedWord.Category);
            Close();
        }

        private void buttonAddTranslate_Click(object sender, EventArgs e)
        {
            if (textBoxRU2.Enabled)
                textBoxRU3.Enabled = true;
            textBoxRU2.Enabled = true;
        }
    }
}
