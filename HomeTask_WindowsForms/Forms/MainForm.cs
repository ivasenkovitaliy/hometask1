using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;
using EnglishAssistant.Services;

namespace EnglishAssistant.Forms
{
    public partial class MainForm : Form
    {
        private readonly Timer _timerForShowingWelcomePanel = new Timer();
        private readonly Timer _timerAfterAnswers = new Timer();
        private readonly AnswerService _answerService = new AnswerService();
        private readonly LocalAppData _localData = LocalAppData.Instance;
        private readonly TestService _testService = new TestService();


        private Word _wordToTranslate = new Word();
        private int _wrongAnswersCount;

        private TypeTest _typeTest = TypeTest.EnglishCheck;

        public MainForm()
        {
            InitializeComponent();

            _timerForShowingWelcomePanel.Interval = 1700;
            _timerForShowingWelcomePanel.Start();
            _timerForShowingWelcomePanel.Tick += TimerToShowWelcomePanel_Tick;

            LostFocus += MainForm_LostFocus;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            Text = Infrastructure.Settings.ProgrammWindowName;

            _localData.TimerForShowingTestWindow.Tick += TimerTest_Tick;

            InitializeAutocompleteForSearchTextBox();
        }

        private void StartTesting()
        {
            PrepareFormForTest();

            _wrongAnswersCount = 0;

            try
            {
                var requiredWords = _testService.GetWordsForTesting(_typeTest);
                _wordToTranslate = requiredWords.First();

                InitializeFormForTest(requiredWords);

                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _timerAfterAnswers.Interval = 1500;
            _timerAfterAnswers.Tick += TimerWrongAnswers_Tick;

            bool isCorrectResult;

            try
            {
                isCorrectResult = IsCorrectResultOfTest();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (isCorrectResult)
            {
                ShowSuccessMessage();

                _answerService.AddAnswer(new Answer(_wordToTranslate.Id, Answer.Type.Right));
                _testService.SetWordIsLearned(_typeTest, _wordToTranslate.Id);

                if (_typeTest != TypeTest.RussianTranslation)
                    _typeTest++;
                else _typeTest = TypeTest.EnglishCheck;

                _timerAfterAnswers.Start();
            }
            else
            {
                if (_wrongAnswersCount < 3)
                {
                    ShowErrorBecauseOfWrongAnswer();

                    if (++_wrongAnswersCount == 3)
                    {
                        ShowEndTestBecauseOfWrongAnswers();
                    }
                }
            }

            ClearFormAfterTest();
        }

        private void InitializeFormForCheck(List<Word> words)
        {
            var random = new Random();
            //displaying radiobuttons captions as variants of right answer
            for (var i = 0; i < 5; i++)
            {
                var rbutton = Controls.Find("radioButtonAnswer" + (i + 1), true);
                var thisStepRandom = random.Next(words.Count);
                if (_typeTest == TypeTest.EnglishCheck)
                    rbutton[0].Text = words[thisStepRandom].Translate;
                else if (_typeTest == TypeTest.RussianCheck) rbutton[0].Text = words[thisStepRandom].Original;
                words.Remove(words.ElementAt(thisStepRandom));
            }

            CategoryNameLabel.Text = _wordToTranslate.Category;
        }

        private bool IsCorrectResultOfTest()
        {
            string correctTranslation = _typeTest == TypeTest.EnglishCheck || _typeTest == TypeTest.EnglishTranslation ?
                _wordToTranslate.Translate
                : _wordToTranslate.Original;

            if (_typeTest == TypeTest.EnglishCheck || _typeTest == TypeTest.RussianCheck)
                return GetResultForCheckTest(correctTranslation);
            else return GetResultForTranslation(correctTranslation);
        }

        private bool GetResultForCheckTest(string correctTranslation)
        {
            var checkedRadioButton = PanelTest.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedRadioButton == null)
            {
                throw new Exception("Choose one variant!");
            }

            return checkedRadioButton.Text == correctTranslation;
        }

        private bool GetResultForTranslation(string correctTranslation)
        {
            return translationRichTextBox.Text.Equals(correctTranslation, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
