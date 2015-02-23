﻿using System;
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
            comboBoxCategories.Items.Clear();

            foreach (var category in LocalAppData.Categories)
            {
                comboBoxCategories.Items.Add(category.CategoryName);
            }
            comboBoxCategories.Text = LocalAppData.Categories.First().CategoryName;
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

            // if there are no empty fields then adding word....
            if (panel1.Controls.OfType<TextBox>().FirstOrDefault(r => r.BackColor == color) == null)
            {
                string translation = textBoxRU1.Text;
                if (textBoxRU2.Enabled)
                    translation += "_" + textBoxRU2.Text;
                if (textBoxRU3.Enabled)
                    translation += "_" + textBoxRU3.Text;

                // and this word already arn't exists.....
                if (LocalAppData.Words.FirstOrDefault(w => w.Original.Equals(textBoxOriginal.Text)) == null)
                {
                    // adding word
                    var wordCategory = LocalAppData.GetCategoryWithCategoryName(comboBoxCategories.Text);
                    _wordRepository.AddWord(textBoxOriginal.Text, translation, wordCategory.CategoryId);
                }
                PrepareForm();
            }
        }
    }
}