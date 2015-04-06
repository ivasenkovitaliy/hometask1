﻿using HomeTask_WindowsForms.DAL;
using HomeTask_WindowsForms.Entities;
using HomeTask_WindowsForms.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HomeTask_WindowsForms.Infrastructure.Extensions;

namespace HomeTask_WindowsForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly Timer _timerForShowingWelcomePanel = new Timer();
        private readonly Timer _timerAfterAnswers = new Timer();
        private readonly Random _rndCounter = new Random();
        private readonly WordRepository _wordRepository = new WordRepository();
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
        private readonly AnswerRepository _answerRepository = new AnswerRepository();
        private readonly AnswerService _answerService = new AnswerService();

        private HashSet<Word> _testingWordsHashSet;
        private Word _wordToTranslate;
        private int _wrongAnswers;

        private bool _englishStep = true;

        public MainForm()
        {
            InitializeComponent();

            this.Text = Properties.Settings.Default.ProgrammWindowName;

            // setting "welcome" timer
            _timerForShowingWelcomePanel.Interval = 1700;
            _timerForShowingWelcomePanel.Start();
            _timerForShowingWelcomePanel.Tick += TimerToShowWelcomePanel_Tick;

            this.FormClosing += MainForm_FormClosing;
            this.LostFocus += MainForm_LostFocus;
            this.Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            LocalAppData.Instance.Categories = _categoryRepository.GetAllCategories().ToList();
            LocalAppData.Instance.Words = _wordRepository.GetAllWords().ToList();
            LocalAppData.Instance.Answers = _answerRepository.GetAllAnswers().ToList();

            LocalAppData.Instance.TimerForShowingTestWindow.Tick += TimerTest_Tick;

            InitializeAutocompleteForSearchTextBox();
        }

        private void InitializeAutocompleteForSearchTextBox()
        {
            var allWords = LocalAppData.Instance.Words;

            var autocompleteCollection = new AutoCompleteStringCollection();
            autocompleteCollection.AddRange(allWords.Select(x => x.Original).ToArray());
            autocompleteCollection.AddRange(allWords.Select(x => x.Translate).ToArray());
            autocompleteCollection.AddRange(allWords.Select(x => x.TranslateSecond).ToArray());
            autocompleteCollection.AddRange(allWords.Select(x => x.TranslateThird).ToArray());

            toolStripWordSearchTextBox.AutoCompleteMode = AutoCompleteMode.Append;
            toolStripWordSearchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolStripWordSearchTextBox.AutoCompleteCustomSource = autocompleteCollection;
        }

        private void StartTesting()
        {
            WelcomeTextLabel.Visible = false;
            LocalAppData.Instance.TimerForShowingTestWindow.Stop();

            //preparing form
            this.WelcomeTextLabel.Visible = false;
            this.labelResult.Visible = false;
            this.buttonAnotherTryNo.Visible = false;
            this.buttonAnotherTryYes.Visible = false;
            this.PanelTest.Visible = true;
            this.buttonCancel.Visible = true;
            this.buttonSubmit.Visible = true;
            this.buttonDontSure.Visible = true;

            // initializing
            _testingWordsHashSet = new HashSet<Word>();
            _wordToTranslate = new Word();
            _wrongAnswers = 0;

            var categories = LocalAppData.Instance.Categories;
            var words = LocalAppData.Instance.Words;
            var wordsInUsedCategories = categories.Where(x => x.IsUsed).SelectMany(x => words.Where(w => w.CategoryId == x.CategoryId)).ToList();
            if (wordsInUsedCategories.Count < 5)
            {
                Hide();
                MessageBox.Show("There are few then 5 words in selected categories, please add words or use more categories");
                return;
            }


            var requiredWords = new List<Word>();
            while (requiredWords.Count < 5)
            {
                // making list of words using nedded categories
                requiredWords = new List<Word>(wordsInUsedCategories);
                requiredWords.RemoveAll(x => _englishStep ? x.IsLearnedEnglish : x.IsLearnedRussian);

                if (requiredWords.Count() < 5)
                {
                    if (_englishStep) _wordRepository.ResetAllEnglishLearnedWords();
                    else _wordRepository.ResetAllRussianLearnedWords();

                    var allWords = _wordRepository.GetAllWords().ToList();

                    LocalAppData.Instance.Words = allWords;
                    wordsInUsedCategories = allWords;
                }

            }

            foreach (var word in requiredWords)
                word.Translate = word.GetRandomTranslate;


                // put word to translate first in hashset
                _testingWordsHashSet.Add(requiredWords[_rndCounter.Next(requiredWords.Count)]);

                // select another 5 un-repeating words
                while (_testingWordsHashSet.Count < 5)
                {
                    _testingWordsHashSet.Add(requiredWords[_rndCounter.Next(requiredWords.Count)]);
                }

                _wordToTranslate = _testingWordsHashSet.First();  // making one word as original

                //displaying radiobuttons captions as variants of right answer
                for (var i = 0; i < 5; i++)
                {
                    var rbutton = this.Controls.Find("radioButtonAnswer" + (i + 1), true);
                    var thisStepRandom = _rndCounter.Next(_testingWordsHashSet.Count);
                    if (_englishStep)
                        rbutton[0].Text = (_testingWordsHashSet.ElementAt(thisStepRandom).Translate);
                    else rbutton[0].Text = (_testingWordsHashSet.ElementAt(thisStepRandom).Original);
                    _testingWordsHashSet.Remove(_testingWordsHashSet.ElementAt(thisStepRandom));
                }

                // displaying test word
                CategoryNameLabel.Text = _wordToTranslate.Category;

                OriginaWordLabel.Text = _englishStep ? _wordToTranslate.Original : _wordToTranslate.Translate;

                Show();
            
        }

        void CancelTest()
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Start();

            this.WelcomeTextLabel.Visible = true;
            this.PanelTest.Visible = false;

            this.Hide();
        }

        void MainForm_LostFocus(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                WelcomeTextLabel.Visible = true;
                WelcomeTextLabel.Text = "Programm is already running!";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                if (this.PanelTest.Visible)
                    _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Cancelled));

                this.PanelWelcome.Visible = false;
                this.PanelTest.Visible = false;
                this.WelcomeTextLabel.Text = "Programm is already running";

                if (this.WelcomeTextLabel.Visible)
                    this.WelcomeTextLabel.Visible = false;

                _timerForShowingWelcomePanel.Stop();

                LocalAppData.Instance.TimerForShowingTestWindow.Start();

                Hide();
            }
        }

        void TimerToShowWelcomePanel_Tick(object sender, EventArgs e)
        {
            this.PanelWelcome.Visible = true;

            _timerForShowingWelcomePanel.Stop();
        }

        private void FirstLayoutNoButton_Click(object sender, EventArgs e)
        {
            this.WelcomeTextLabel.Text = "Programm is already running";
            this.PanelWelcome.Visible = false;

            _timerForShowingWelcomePanel.Stop();

            LocalAppData.Instance.TimerForShowingTestWindow.Start();

            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FirstLayoutYesButton_Click(object sender, EventArgs e)
        {
            this.PanelWelcome.Visible = false;

            StartTesting();
        }

        private void StartTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTesting();
        }

        public void TimerTest_Tick(object sender, EventArgs e)
        {
            // setting non-active user interval as 0,9 of testtimer interval
            var nonActiveUserInterval = LocalAppData.Instance.TimerForShowingTestWindow.Interval * 0.0009;

            if (Program.GetLastInputTime() < nonActiveUserInterval)
                StartTesting();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _timerAfterAnswers.Interval = 1500;
            _timerAfterAnswers.Tick += TimerWrongAnswers_Tick;

            var checkedRadioButton = PanelTest.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            string correctTranslation = _englishStep ? _wordToTranslate.Translate : _wordToTranslate.Original;

            if (checkedRadioButton == null)
                MessageBox.Show("choose something!");

            else if (checkedRadioButton.Text == correctTranslation)
            {
                labelResult.Visible = true;

                labelResult.Text = "Correct!";

                // adding "right" answer to statistic
                _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Right));

                var wordFromSet = LocalAppData.Instance.Words.Find(x => x.Id == _wordToTranslate.Id);
                if (_englishStep)
                    wordFromSet.IsLearnedEnglish = true;
                else wordFromSet.IsLearnedRussian = true;

                _wordRepository.UpdateWord(wordFromSet);

                _englishStep = !_englishStep;

                _timerAfterAnswers.Start();
            }

            else
            {
                if (_wrongAnswers < 3)
                {
                    labelResult.Visible = true;
                    labelResult.Text = "wrong.... another try?";
                    this.buttonSubmit.Visible = false;
                    this.buttonDontSure.Visible = false;
                    this.buttonCancel.Visible = false;

                    this.buttonAnotherTryYes.Visible = true;
                    this.buttonAnotherTryNo.Visible = true;

                    if (++_wrongAnswers == 3)
                    {
                        labelResult.Visible = true;
                        this.buttonAnotherTryYes.Visible = false;
                        this.buttonAnotherTryNo.Visible = false;
                        labelResult.Text = "sorry, you haven't any try";

                        //adding "wrong" to statistic
                        _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Wrong));

                        _timerAfterAnswers.Start();
                    }
                }
            }

            // to deactivate selected radiobutton
            if (checkedRadioButton != null && checkedRadioButton.Checked)
                checkedRadioButton.Checked = false;
        }

        void TimerWrongAnswers_Tick(object sender, EventArgs e)
        {
            _timerAfterAnswers.Stop();

            this.buttonSubmit.Visible = true;
            this.buttonDontSure.Visible = true;
            this.buttonCancel.Visible = true;

            CancelTest();
        }

        private void buttonAnotherTryYes_Click(object sender, EventArgs e)
        {
            this.buttonAnotherTryYes.Visible = false;
            this.buttonAnotherTryNo.Visible = false;
            this.labelResult.Visible = false;
            this.buttonSubmit.Visible = true;
            this.buttonDontSure.Visible = true;
            this.buttonCancel.Visible = true;
        }

        private void buttonAnotherTryNo_Click(object sender, EventArgs e)
        {
            _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Wrong));

            CancelTest();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Cancelled));

            CancelTest();
        }

        private void buttonDontSure_Click(object sender, EventArgs e)
        {
            _timerAfterAnswers.Interval = 1500;
            _timerAfterAnswers.Tick += TimerWrongAnswers_Tick;

            this.labelResult.Visible = true;
            this.buttonAnotherTryYes.Visible = false;
            this.buttonAnotherTryNo.Visible = false;
            labelResult.Text = "sorry, you don't khow....";

            // adding "wrong" to statistic
            _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Wrong));

            _timerAfterAnswers.Start();
        }

        private void categoriesManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Stop();

            var form = new CategoriesManagement();
            form.Show();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Stop();

            var form = new Settings();
            form.Show();
        }
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Stop();

            var form = new Statistic();
            form.Show();
        }

        private void wordsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Stop();

            var form = new WordsManagement();
            form.Show();
        }

        private void AddNewWord(object sender, EventArgs e)
        {
            new AddingWord().Show();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
            {
                AddNewWord(null, null);
            }
        }

        private void toolStripWordSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (ToolStripTextBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                var searchValue = textBox.Text;
                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    textBox.Text = "Search your word...";
                    return;
                }

                var allWords = LocalAppData.Instance.Words;

                var requeryWord = allWords.FirstOrDefault(x => x.IsOriginalOrTranslation(searchValue));
                if (requeryWord == null)
                    return;

                new UpdatingWord(requeryWord).Show();
            }
        }

        private void toolStripWordSearchTextBox_Click(object sender, EventArgs e)
        {
            ((ToolStripTextBox)sender).Text = string.Empty;
        }
    }
}
