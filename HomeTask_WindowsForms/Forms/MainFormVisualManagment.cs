using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;

namespace EnglishAssistant.Forms
{
    partial class MainForm
    {
        private void InitializeAutocompleteForSearchTextBox()
        {
            var allWords = _localData.Words;

            var autocompleteCollection = new AutoCompleteStringCollection();
            autocompleteCollection.AddRange(allWords.Select(x => x.Original).ToArray());
            autocompleteCollection.AddRange(allWords.Select(x => x.Translate).ToArray());
            autocompleteCollection.AddRange(allWords.Select(x => x.TranslateSecond).ToArray());
            autocompleteCollection.AddRange(allWords.Select(x => x.TranslateThird).ToArray());

            toolStripWordSearchTextBox.AutoCompleteMode = AutoCompleteMode.Append;
            toolStripWordSearchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolStripWordSearchTextBox.AutoCompleteCustomSource = autocompleteCollection;
        }

        private void PrepareFormForTest()
        {
            WelcomeTextLabel.Visible = false;
            PanelTest.Visible = true;
            labelResult.Visible = false;
            _localData.TimerForShowingTestWindow.Stop();

            if (_typeTest == TypeTest.EnglishCheck || _typeTest == TypeTest.RussianCheck)
            {
                WelcomeTextLabel.Visible = false;
                buttonAnotherTryNo.Visible = false;
                buttonAnotherTryYes.Visible = false;
            }
            else
            {
                translationRichTextBox.Visible = true;
            }
            buttonCancel.Visible = true;
            buttonSubmit.Visible = true;
            buttonDontSure.Visible = true;
        }

        private void InitializeFormForTest(List<Word> words)
        {
            OriginaWordLabel.Text = _typeTest == TypeTest.EnglishCheck || _typeTest == TypeTest.EnglishTranslation
                                    ? _wordToTranslate.Original
                                    : _wordToTranslate.Translate;

            if (_typeTest == TypeTest.EnglishCheck || _typeTest == TypeTest.RussianCheck)
                InitializeFormForCheck(words);
            else InitializeFormForTranslation();
        }

        private void ShowSuccessMessage()
        {
            labelResult.Visible = true;
            labelResult.Text = "Correct!";
        }

        private void ClearFormAfterTest()
        {
            var checkedVariant = PanelTest.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedVariant != null) checkedVariant.Checked = false;

            translationRichTextBox.Text = string.Empty;
        }

        private void ShowErrorBecauseOfWrongAnswer()
        {
            labelResult.Visible = true;
            labelResult.Text = "Wrong... Do you want one more try?";
            buttonSubmit.Visible = false;
            buttonDontSure.Visible = false;
            buttonCancel.Visible = false;

            buttonAnotherTryYes.Visible = true;
            buttonAnotherTryNo.Visible = true;
        }

        private void ShowEndTestBecauseOfWrongAnswers()
        {
            labelResult.Visible = true;
            buttonAnotherTryYes.Visible = false;
            buttonAnotherTryNo.Visible = false;
            translationRichTextBox.Visible = false;
            labelResult.Text = "Sorry, you have no more tries";

            //adding "wrong" to statistic
            _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Wrong));

            _timerAfterAnswers.Start();
        }

    }
}
