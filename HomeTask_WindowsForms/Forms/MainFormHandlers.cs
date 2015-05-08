using System;
using System.Linq;
using System.Windows.Forms;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;
using EnglishAssistant.Infrastructure.Extensions;

namespace EnglishAssistant.Forms
{
    partial class MainForm
    {
        void CancelTest()
        {
            _localData.TimerForShowingTestWindow.Start();

            WelcomeTextLabel.Visible = true;
            PanelTest.Visible = false;
            translationRichTextBox.Visible = false;
            translationRichTextBox.Text = string.Empty;

            Hide();
        }

        void MainForm_LostFocus(object sender, EventArgs e)
        {
            if (Visible) return;

            WelcomeTextLabel.Visible = true;
            WelcomeTextLabel.Text = "Programm is already running!";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                if (PanelTest.Visible)
                    _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Cancelled));

                PanelWelcome.Visible = false;
                PanelTest.Visible = false;
                WelcomeTextLabel.Text = "Programm is already running";

                if (WelcomeTextLabel.Visible)
                    WelcomeTextLabel.Visible = false;

                _timerForShowingWelcomePanel.Stop();

                LocalAppData.Instance.TimerForShowingTestWindow.Start();

                Hide();
            }
        }

        void TimerToShowWelcomePanel_Tick(object sender, EventArgs e)
        {
            PanelWelcome.Visible = true;

            _timerForShowingWelcomePanel.Stop();
        }

        private void FirstLayoutNoButton_Click(object sender, EventArgs e)
        {
            WelcomeTextLabel.Text = "Programm is already running";
            PanelWelcome.Visible = false;

            _timerForShowingWelcomePanel.Stop();

            _localData.TimerForShowingTestWindow.Start();

            Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FirstLayoutYesButton_Click(object sender, EventArgs e)
        {
            PanelWelcome.Visible = false;

            StartTesting();
        }

        private void StartTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTesting();
        }

        public void TimerTest_Tick(object sender, EventArgs e)
        {
            // setting non-active user interval as 0,9 of testtimer interval
            var nonActiveUserInterval = _localData.TimerForShowingTestWindow.Interval * 0.0009;

            if (Program.GetLastInputTime() < nonActiveUserInterval)
                StartTesting();
        }

        private void buttonAnotherTryYes_Click(object sender, EventArgs e)
        {
            buttonAnotherTryYes.Visible = false;
            buttonAnotherTryNo.Visible = false;
            labelResult.Visible = false;
            buttonSubmit.Visible = true;
            buttonDontSure.Visible = true;
            buttonCancel.Visible = true;
            translationRichTextBox.Text = string.Empty;
        }

        void TimerWrongAnswers_Tick(object sender, EventArgs e)
        {
            _timerAfterAnswers.Stop();

            buttonSubmit.Visible = true;
            buttonDontSure.Visible = true;
            buttonCancel.Visible = true;

            CancelTest();
        }

        private void buttonAnotherTryNo_Click(object sender, EventArgs e)
        {
            _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Wrong));

            buttonAnotherTryYes.Visible = false;
            buttonAnotherTryNo.Visible = false;

            CancelTest();

            ClearFormAfterTest();
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

            labelResult.Visible = true;
            buttonAnotherTryYes.Visible = false;
            buttonAnotherTryNo.Visible = false;
            labelResult.Text = "Better luck next time!";

            _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Wrong));

            _timerAfterAnswers.Start();
        }

        private void categoriesManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _localData.TimerForShowingTestWindow.Stop();

            new CategoriesManagement().Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _localData.TimerForShowingTestWindow.Stop();

            new Settings().Show();
        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _localData.TimerForShowingTestWindow.Stop();

            new Statistic().Show();
        }

        private void wordsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _localData.TimerForShowingTestWindow.Stop();

            new WordsManagement().Show();
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

                var allWords = _localData.Words;

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

        private void InitializeFormForTranslation()
        {
            translationRichTextBox.Visible = true;
        }
    }
}
