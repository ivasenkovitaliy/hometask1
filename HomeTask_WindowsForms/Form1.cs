using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeTask_WindowsForms;

namespace HomeTask_WindowsForms
{

        
    

    public partial class MainForm : Form
    {
        private HashSet<Word> _testWordsHashSet;
        private Word _wordToTranslate;
        private Control _checkedRadioButton;
        private int _wrongAnswers;
        private int _testInterval = 10000; // 10 sec
        
        //private Word _randomWord;

        Timer TimerToShowWelcomePanel = new Timer();
        Timer TimerAnswers = new Timer();
        Timer TimerTest= new Timer();

        WordsRepository repository = new WordsRepository(); // singleton

        List<Word> _programmWords = new List<Word>();
        //private Word wordToTranslate;
        
        
        Random rndCounter = new Random();
        

        
        public MainForm(string windowName)
        {
            InitializeComponent();
            this.Text = windowName;
            
            // setting "welcome" timer
            TimerToShowWelcomePanel.Interval = 1000;
            TimerToShowWelcomePanel.Start();
            TimerToShowWelcomePanel.Tick += TimerToShowWelcomePanel_Tick;
            
            //setting timer displaying test window
            TimerTest.Interval = _testInterval;
            TimerTest.Tick += TimerTest_Tick;
            
            this.FormClosing+=MainForm_FormClosing;

            
            
        }

        // user-clik to close form -> hiding window
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.PanelWelcome.Visible = false;
                if (this.WelcomeTextLabel.Visible)
                    this.WelcomeTextLabel.Visible = false;
                TimerToShowWelcomePanel.Stop();
                this.WelcomeTextLabel.Text = "Programm is already executing";

                TimerTest.Start();
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

        // hiding window
        private void FirstLayoutNoButton_Click(object sender, EventArgs e)
        {
            this.WelcomeTextLabel.Text = "Programm is already executing";
            this.PanelWelcome.Visible = false;
            TimerToShowWelcomePanel.Stop();


            TimerTest.Start();
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
            Testing();
            // here will be activating panel for test
        }

        // showing window -> start test with context menu
        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Testing();
        }

        // showing window -> start test on timer
        void TimerTest_Tick(object sender, EventArgs e)
        {
            var neddedInterval = TimerTest.Interval * 0.0007;
            if (Program.GetLastInputTime() < neddedInterval)
                Testing();
        }

        void Testing()
        {
            TimerTest.Stop();
            this.WelcomeTextLabel.Visible = false;
            this.PanelTest.Visible = true;
            this.labelResult.Visible = false;

            this.radioButtonAnswer1.Checked = false;
            this.radioButtonAnswer2.Checked = false;
            this.radioButtonAnswer3.Checked = false;
            this.radioButtonAnswer4.Checked = false;
            this.radioButtonAnswer5.Checked = false;

            // local



            // initializing
            _testWordsHashSet = new HashSet<Word>(); 
            _wordToTranslate = new Word(); // word to translate
            _wrongAnswers = 0;

            //Word[] wordsForVariants = new Word[5]; // words for answer variants
            
            // getting all words
            _programmWords = repository.GetAllWords();
            
            // put word to translate first in hashset
            _testWordsHashSet.Add(_programmWords[rndCounter.Next(_programmWords.Count)]);

            // select another 5 un-repeating words
            while (_testWordsHashSet.Count < 5)
            {
                _testWordsHashSet.Add(_programmWords[rndCounter.Next(_programmWords.Count)] );
            }

            _wordToTranslate = _testWordsHashSet.First();  // making one word as original
            
            
            //setting radiobuttons captions
            for (int i = 0; i < 5; i++)
            {
                Control[] rbutton = this.Controls.Find("radioButtonAnswer"+(i+1), true);
                int thisStepRandom = rndCounter.Next(_testWordsHashSet.Count);
                rbutton[0].Text = (_testWordsHashSet.ElementAt(thisStepRandom).GetTranslate());
                _testWordsHashSet.Remove(_testWordsHashSet.ElementAt(thisStepRandom));

            }
            

            

            // displaying 
            CategoryNameLabel.Text = _wordToTranslate.GetCategory();
            OriginaWordLabel.Text = _wordToTranslate.GetOriginal();


            
            this.Show();
        }

        void CancelTest()
        {
            // adding "wrong" to statistic
            TimerTest.Start();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TimerAnswers.Interval = 1500;
            TimerAnswers.Tick += TimerWrongAnswers_Tick;

            if (_checkedRadioButton == null)
            {
                MessageBox.Show("choose something!");
            }

            else if ( _checkedRadioButton.Text == _wordToTranslate.GetTranslate())
            {
                labelResult.Visible = true;
                labelResult.Text = "Wright!";
                
                // adding "right" to statistic 
                TimerAnswers.Start();

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
                        TimerAnswers.Start();
                    }
                        
                }
            }

        }

        void TimerWrongAnswers_Tick(object sender, EventArgs e)
        {
            TimerAnswers.Stop();
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
            TimerAnswers.Interval = 1500;
            TimerAnswers.Tick += TimerWrongAnswers_Tick;

            labelResult.Visible = true;
            this.buttonAnotherTryYes.Visible = false;
            this.buttonAnotherTryNo.Visible = false;
            labelResult.Text = "sorry, you don't khow....";
            TimerAnswers.Start();
        }

        

        
        
    }
}
