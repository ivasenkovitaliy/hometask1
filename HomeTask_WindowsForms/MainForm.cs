using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    
    public partial class MainForm : Form
    {
        private HashSet<Word> _testWordsHashSet;
        private Word _wordToTranslate;
        private Control _checkedRadioButton; // to see checked answer
        private int _wrongAnswers;
        public HashSet<Category> Categories { get; set; }
        public int TestInterval { get; set; }
        public Repository repository = new Repository(); // will be singleton later ))
        public Timer TimerToShowTestWindow = new Timer(); // ask question to Artur or Yura
        public List<Word> Words = new List<Word>(); // ask question to Artur or Yura

        Timer TimerToShowWelcomePanel = new Timer();
        Timer TimerAfterAnswers = new Timer();
        
        Random rndCounter = new Random();

        public MainForm(string windowName)
        {
            InitializeComponent();
            TestInterval = 180000;
            //TestInterval = Convert.ToInt16(Settings.domainUpDown1.Text)*60000;
            
            // setting "welcome" timer
            TimerToShowWelcomePanel.Interval = 1000;
            TimerToShowWelcomePanel.Start();
            TimerToShowWelcomePanel.Tick += TimerToShowWelcomePanel_Tick;
            
            //setting timer displaying test window
            TimerToShowTestWindow.Interval = TestInterval;
            TimerToShowTestWindow.Tick += TimerTest_Tick;

            // getting all words from database
            Words = repository.GetAllWords();

            // getting all categories in hashset
            CategoryComparer comparer = new CategoryComparer();
            Categories = new HashSet<Category>(comparer);
            
            //making categoires
            foreach (var currentWord in Words)
            {
                //var x = new Category(currentWord.GetCategory(), true);
                Categories.Add(new Category(currentWord.GetCategory(), true));
            }

            this.FormClosing+=MainForm_FormClosing;
            this.LostFocus += MainForm_LostFocus;
        }

        // ----------------------------------------------------------------------------
        private void StartTesting()
        {
            WelcomeTextLabel.Visible = false;
            TimerToShowTestWindow.Stop();
            
            //preparing form
            this.WelcomeTextLabel.Visible = false;
            this.PanelTest.Visible = true;
            this.labelResult.Visible = false;
            this.buttonAnotherTryNo.Visible = false;
            this.buttonAnotherTryYes.Visible = false;
            this.buttonCancel.Visible = true;
            this.buttonSubmit.Visible = true;
            this.buttonDontSure.Visible = true;

            this.radioButtonAnswer1.Checked = false;
            this.radioButtonAnswer2.Checked = false;
            this.radioButtonAnswer3.Checked = false;
            this.radioButtonAnswer4.Checked = false;
            this.radioButtonAnswer5.Checked = false;
            
            // initializing
            _testWordsHashSet = new HashSet<Word>();
            _wordToTranslate = new Word(); // word to translate
            _wrongAnswers = 0;

            // making list of words using nedded categories
            List<Word> wordsWithCategories = new List<Word>();
            
            // put words with selected categories
            foreach (var category in Categories)
            {
                if (category.GetCategoryUsed())
                    foreach (var word in Words)
                    {
                        if(word.GetCategory()==category.GetCategory())
                        wordsWithCategories.Add(word);
                    }
            }

            // put word to translate first in hashset
            _testWordsHashSet.Add(wordsWithCategories[rndCounter.Next(wordsWithCategories.Count)]);
            
            // select another 5 un-repeating words
            while (_testWordsHashSet.Count < 5)
            {
                _testWordsHashSet.Add(wordsWithCategories[rndCounter.Next(wordsWithCategories.Count)]);
            }

            _wordToTranslate = _testWordsHashSet.First();  // making one word as original
            
            //displaying radiobuttons captions as variants of right answer
            for (int i = 0; i < 5; i++)
            {
                Control[] rbutton = this.Controls.Find("radioButtonAnswer" + (i + 1), true);
                int thisStepRandom = rndCounter.Next(_testWordsHashSet.Count);
                rbutton[0].Text = (_testWordsHashSet.ElementAt(thisStepRandom).GetTranslate());
                _testWordsHashSet.Remove(_testWordsHashSet.ElementAt(thisStepRandom));
            }

            // displaying test word
            CategoryNameLabel.Text = _wordToTranslate.GetCategory();
            OriginaWordLabel.Text = _wordToTranslate.GetOriginal();

            this.Show();
        }

        void CancelTest()
        {
            // adding "wrong" to statistic

            TimerToShowTestWindow.Start();
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
                TimerToShowWelcomePanel.Stop();
                this.WelcomeTextLabel.Text = "Programm is already running";
                TimerToShowTestWindow.Interval = TestInterval;
                TimerToShowTestWindow.Start();
                Hide();
            }
            //throw new NotImplementedException();
        }

        void TimerToShowWelcomePanel_Tick(object sender, EventArgs e)
        {
            this.PanelWelcome.Visible = true;
            TimerToShowWelcomePanel.Stop();
            //throw new NotImplementedException();
        }

        private void FirstLayoutNoButton_Click(object sender, EventArgs e)
        {
            this.WelcomeTextLabel.Text = "Programm is already running";
            this.PanelWelcome.Visible = false;
            TimerToShowWelcomePanel.Stop();
            TimerToShowTestWindow.Start();
            this.Hide();
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // starting test
        private void FirstLayoutYesButton_Click(object sender, EventArgs e)
        {
            this.PanelWelcome.Visible = false;
            StartTesting();
        }

        // showing window -> start test with context menu
        private void StartTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTesting();
        }

        // showing window -> start test on timer
        void TimerTest_Tick(object sender, EventArgs e)
        {
            var neddedInterval = TimerToShowTestWindow.Interval * 0.0009;
            if (Program.GetLastInputTime() < neddedInterval)
                StartTesting();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            TimerAfterAnswers.Interval = 1500;
            TimerAfterAnswers.Tick += TimerWrongAnswers_Tick;

            if (_checkedRadioButton == null)
                MessageBox.Show("choose something!");
            
            else if ( _checkedRadioButton.Text == _wordToTranslate.GetTranslate())
            {
                labelResult.Visible = true;
                labelResult.Text = "Wright!";
                
                // adding "right" to statistic 

                TimerAfterAnswers.Start();
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

                        TimerAfterAnswers.Start();
                    }
                        
                }
            }

        }

        void TimerWrongAnswers_Tick(object sender, EventArgs e)
        {
            TimerAfterAnswers.Stop();
            this.buttonSubmit.Visible = true;
            this.buttonDontSure.Visible = true;
            this.buttonCancel.Visible = true;
            CancelTest();
            //throw new NotImplementedException();
        }

        private void radioButtonAnswer1_CheckedChanged(object sender, EventArgs e)
        {
            _checkedRadioButton = this.radioButtonAnswer1;
        }

        private void radioButtonAnswer2_CheckedChanged(object sender, EventArgs e)
        {
            _checkedRadioButton = this.radioButtonAnswer2;
        }

        private void radioButtonAnswer3_CheckedChanged(object sender, EventArgs e)
        {
            _checkedRadioButton = this.radioButtonAnswer3;
        }

        private void radioButtonAnswer4_CheckedChanged(object sender, EventArgs e)
        {
            _checkedRadioButton = this.radioButtonAnswer4;
        }

        private void radioButtonAnswer5_CheckedChanged(object sender, EventArgs e)
        {
            _checkedRadioButton = this.radioButtonAnswer5;
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
            TimerAfterAnswers.Interval = 1500;
            TimerAfterAnswers.Tick += TimerWrongAnswers_Tick;
            this.labelResult.Visible = true;
            this.buttonAnotherTryYes.Visible = false;
            this.buttonAnotherTryNo.Visible = false;
            labelResult.Text = "sorry, you don't khow....";
            
            // adding "wrong" to statistic

            TimerAfterAnswers.Start();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerToShowTestWindow.Stop();
            Settings form = new Settings(this);
            form.Show();
        }

        private void categoriesManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerToShowTestWindow.Stop();
            CategoriesManagement form = new CategoriesManagement(this);
            form.Show();
        }

        
    }
}
