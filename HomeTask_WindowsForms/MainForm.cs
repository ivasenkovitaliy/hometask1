using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class MainForm : Form
    {
        private readonly Timer _timerForShowingWelcomePanel = new Timer();
        private readonly Timer _timerAfterAnswers = new Timer();
        private readonly Random _rndCounter = new Random();
        private readonly DBRepository _dbRepository = new DBRepository();
        private HashSet<Word> _testingWordsHashSet;
        private Word _wordToTranslate;
        private int _wrongAnswers;
        
        public MainForm(string windowName)
        {
            InitializeComponent();
            this.Text = windowName;

            // setting "welcome" timer
            _timerForShowingWelcomePanel.Interval = 1700;
            _timerForShowingWelcomePanel.Start();
            _timerForShowingWelcomePanel.Tick += TimerToShowWelcomePanel_Tick;
            
            this.FormClosing+=MainForm_FormClosing;
            this.LostFocus += MainForm_LostFocus;
            this.Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            Answers.GetInstance();
            LocalRepository.GetInstance();

            // getting all words from database
            LocalRepository.Words = _dbRepository.GetAllWords();

            // getting all categories in hashset
            CategoryComparer comparer = new CategoryComparer();
            LocalRepository.Categories = new HashSet<Category>(comparer);

            //making all categoires
            foreach (var currentWord in LocalRepository.Words)
            {
                LocalRepository.Categories.Add(new Category(currentWord._category, true));
            }

            // add non-used categories
            var allCategories = _dbRepository.GetAllCategories();
            foreach (var category in allCategories)
            {
                LocalRepository.Categories.Add(category);
            }

            LocalRepository.TimerForShowingTestWindow.Tick += TimerTest_Tick;
            //throw new NotImplementedException();
        }
        // ----------------------------------------------------------------------------
        private void StartTesting()
        {
            WelcomeTextLabel.Visible = false;
            LocalRepository.TimerForShowingTestWindow.Stop();
            
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

            // making list of words using nedded categories
            List<Word> wordsWithCategories = new List<Word>();
            
            // put words with selected categories
            foreach (var category in LocalRepository.Categories)
            {
                if (category.IsUsed)
                    foreach (var word in LocalRepository.Words)
                    {
                        if(word._category==category.GetCategory)
                        wordsWithCategories.Add(word);
                    }
            }

            // put word to translate first in hashset
            _testingWordsHashSet.Add(wordsWithCategories[_rndCounter.Next(wordsWithCategories.Count)]);
            
            // select another 5 un-repeating words
            while (_testingWordsHashSet.Count < 5)
            {
                _testingWordsHashSet.Add(wordsWithCategories[_rndCounter.Next(wordsWithCategories.Count)]);
            }

            _wordToTranslate = _testingWordsHashSet.First();  // making one word as original
            
            //displaying radiobuttons captions as variants of right answer
            for (int i = 0; i < 5; i++)
            {
                Control[] rbutton = this.Controls.Find("radioButtonAnswer" + (i + 1), true);
                int thisStepRandom = _rndCounter.Next(_testingWordsHashSet.Count);
                rbutton[0].Text = (_testingWordsHashSet.ElementAt(thisStepRandom)._translate);
                _testingWordsHashSet.Remove(_testingWordsHashSet.ElementAt(thisStepRandom));
            }

            // displaying test word
            CategoryNameLabel.Text = _wordToTranslate._category;
            OriginaWordLabel.Text = _wordToTranslate._original;

            this.Show();
        }

        void CancelTest()
        {
            LocalRepository.TimerForShowingTestWindow.Start();
            this.WelcomeTextLabel.Visible = true;
            this.PanelTest.Visible = false;
            this.Hide();
        }
        //-------------------------------------------------------------------------
        
        void MainForm_LostFocus(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                WelcomeTextLabel.Visible = true;
                WelcomeTextLabel.Text = "Programm is already running!";
            }
            //throw new NotImplementedException();
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.PanelWelcome.Visible = false;
                this.PanelTest.Visible = false;
                if (this.WelcomeTextLabel.Visible)
                    this.WelcomeTextLabel.Visible = false;
                _timerForShowingWelcomePanel.Stop();
                this.WelcomeTextLabel.Text = "Programm is already running";
                LocalRepository.TimerForShowingTestWindow.Start();
                Hide();
            }
            //throw new NotImplementedException();
        }

        void TimerToShowWelcomePanel_Tick(object sender, EventArgs e)
        {
            this.PanelWelcome.Visible = true;
            _timerForShowingWelcomePanel.Stop();
            //throw new NotImplementedException();
        }

        private void FirstLayoutNoButton_Click(object sender, EventArgs e)
        {
            this.WelcomeTextLabel.Text = "Programm is already running";
            this.PanelWelcome.Visible = false;
            _timerForShowingWelcomePanel.Stop();
            LocalRepository.TimerForShowingTestWindow.Start();
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
            var nonActiveUserInterval = LocalRepository.TimerForShowingTestWindow.Interval * 0.0009;
            if (Program.GetLastInputTime() < nonActiveUserInterval)
                StartTesting();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _timerAfterAnswers.Interval = 1500;
            _timerAfterAnswers.Tick += TimerWrongAnswers_Tick;

            var checkedRadioButton = PanelTest.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            if (checkedRadioButton == null)
                MessageBox.Show("choose something!");
            
            else if ( checkedRadioButton.Text == _wordToTranslate._translate)
            {
                labelResult.Visible = true;
                labelResult.Text = "Wright!";
                
                // adding "right" answer to statistic 
                Answers.AddAnswer(true);
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
                        Answers.AddAnswer(false);
                        _timerAfterAnswers.Start();
                    }
                }
            }
            // to deactivate selected radiobutton
            if(checkedRadioButton!=null && checkedRadioButton.Checked)
                checkedRadioButton.Checked = false;
        }

        void TimerWrongAnswers_Tick(object sender, EventArgs e)
        {
            _timerAfterAnswers.Stop();
            this.buttonSubmit.Visible = true;
            this.buttonDontSure.Visible = true;
            this.buttonCancel.Visible = true;
            CancelTest();
            //throw new NotImplementedException();
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
            CancelTest();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
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
            Answers.AddAnswer(false);
            _timerAfterAnswers.Start();
        }

        private void categoriesManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Stop();
            CategoriesManagement form = new CategoriesManagement();
            form.Show();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Stop();
            Settings form = new Settings();
            form.Show();
        }
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TimerToShowTestWindow.Stop();
            Statistic form = new Statistic();
            form.Show();
        }

        private void wordsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Stop();
            WordsManagement form = new WordsManagement();
            form.Show();
        }
    }
}
