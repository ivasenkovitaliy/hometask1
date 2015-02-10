using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{

        
    

    public partial class MainForm : Form
    {
        private HashSet<Word> _testWordsHashSet;
        private Word _wordToTranslate;
        private Control _checkedRadioButton;
        private int _wrongAnswers;
        private int _testInterval; // in miliseconds
        
        
        Timer TimerToShowWelcomePanel = new Timer();
        Timer TimerAfterAnswers = new Timer();
        Timer TimerToShowTestWindow= new Timer();

        WordsRepository repository = new WordsRepository(); // singleton
        List<Word> _programmWords = new List<Word>();
        
        
        
        Random rndCounter = new Random();
        

        
        public MainForm(string windowName)
        {
            InitializeComponent();

            _testInterval = Convert.ToInt16(domainUpDown1.Text)*60000;
            this.Text = windowName;
            
            // setting "welcome" timer
            TimerToShowWelcomePanel.Interval = 1000;
            TimerToShowWelcomePanel.Start();
            TimerToShowWelcomePanel.Tick += TimerToShowWelcomePanel_Tick;
            
            //setting timer displaying test window
            TimerToShowTestWindow.Interval = _testInterval;
            TimerToShowTestWindow.Tick += TimerTest_Tick;
            
            this.FormClosing+=MainForm_FormClosing;

            
            
        }

        // ----------------------------------------------------------------------------
        private void StartTesting()
        {
            TimerToShowTestWindow.Stop();
            
            //preparing form
            this.WelcomeTextLabel.Visible = false;
            this.PanelTest.Visible = true;
            this.labelResult.Visible = false;

            this.radioButtonAnswer1.Checked = false;
            this.radioButtonAnswer2.Checked = false;
            this.radioButtonAnswer3.Checked = false;
            this.radioButtonAnswer4.Checked = false;
            this.radioButtonAnswer5.Checked = false;


            // initializing
            _testWordsHashSet = new HashSet<Word>();
            _wordToTranslate = new Word(); // word to translate
            _wrongAnswers = 0;

            // getting all words
            _programmWords = repository.GetAllWords();

            // put word to translate first in hashset
            _testWordsHashSet.Add(_programmWords[rndCounter.Next(_programmWords.Count)]);

            // select another 5 un-repeating words
            while (_testWordsHashSet.Count < 5)
            {
                _testWordsHashSet.Add(_programmWords[rndCounter.Next(_programmWords.Count)]);
            }

            _wordToTranslate = _testWordsHashSet.First();  // making one word as original


            //setting radiobuttons captions
            for (int i = 0; i < 5; i++)
            {
                Control[] rbutton = this.Controls.Find("radioButtonAnswer" + (i + 1), true);
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
            TimerToShowTestWindow.Start();
            this.PanelTest.Visible = false;
            this.Hide();
        }

        //-------------------------------------------------------------------------


        // user-clik to close form -> hiding window
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // auto-closing panels
            if (PanelSetttings.Visible)
                PanelSetttings.Visible = false;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.PanelWelcome.Visible = false;
                if (this.WelcomeTextLabel.Visible)
                    this.WelcomeTextLabel.Visible = false;
                TimerToShowWelcomePanel.Stop();
                this.WelcomeTextLabel.Text = "Programm is already executing";

                TimerToShowTestWindow.Interval = _testInterval;
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

        // hiding window
        private void FirstLayoutNoButton_Click(object sender, EventArgs e)
        {
            this.WelcomeTextLabel.Text = "Programm is already executing";
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
            // here will be activating panel for test
        }

        // showing window -> start test with context menu
        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            TimerAfterAnswers.Interval = 1500;
            TimerAfterAnswers.Tick += TimerWrongAnswers_Tick;

            if (_checkedRadioButton == null)
            {
                MessageBox.Show("choose something!");
            }

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

            labelResult.Visible = true;
            this.buttonAnotherTryYes.Visible = false;
            this.buttonAnotherTryNo.Visible = false;
            labelResult.Text = "sorry, you don't khow....";

            

            // adding "wrong" to statistic

            TimerAfterAnswers.Start();
        }











        static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }









        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<string[]> list = new List<string[]>();
            //list.Add(new string[] { "Column 1", "Column 2", "Column 3" });
            //list.Add(new string[] { "Row 2", "Row 2" });
            //list.Add(new string[] { "Row 3" });


            //DataTable table = ConvertListToDataTable(list);
            //dataGridView1.DataSource = table;

            DataGridViewCheckBoxColumn columnCheckBox = new DataGridViewCheckBoxColumn();
            {
                //column.HeaderText = "OutOfOffice";
                //column.Name = "OutOfOffice";
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //column.FlatStyle = FlatStyle.Standard;
                //column.ThreeState = true;
                columnCheckBox.CellTemplate = new DataGridViewCheckBoxCell();
                //column.CellTemplate.Style.BackColor = Color.Beige;
                
                //var x = column.TrueValue;
            }

            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            {
                col.CellTemplate = new DataGridViewTextBoxCell();
                col.ReadOnly = true;
            }
            //DataGridViewCheckBoxColumn columnCheckBox = new DataGridViewCheckBoxColumn();


             dataGridView1.AllowUserToAddRows = false;
             dataGridView1.AllowUserToDeleteRows = false;

             dataGridView1.Columns.Insert(0, columnCheckBox);
             dataGridView1.Columns.Insert(0, col);

            DataGridViewCell cell = dataGridView1.Rows[0].Cells[0];

            TimerToShowTestWindow.Stop();
            PanelSetttings.Visible = true;
            this.Show();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonSubmitTestPanel_Click(object sender, EventArgs e)
        {
            _testInterval = Convert.ToInt16(domainUpDown1.Text) * 60000;

            this.Close();
        }

        private void buttonCancel_PanelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
