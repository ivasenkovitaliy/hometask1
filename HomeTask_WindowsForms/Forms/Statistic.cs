using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeTask_WindowsForms
{
    public partial class Statistic : Form
    {
        private readonly AnswerRepository _answerRepository = new AnswerRepository();
        
        public Statistic()
        {
            InitializeComponent();
            DrawStatistic();
            
            this.FormClosing += Statistic_FormClosing;
        }

        void Statistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalAppData.TimerForShowingTestWindow.Start();
            //throw new NotImplementedException();
        }

        private void DrawStatistic()
        {
            List<Answer> selectedAnswerList = new List<Answer>();
            
            LocalAppData.Answers = _answerRepository.GetAllAnswers();
            
            var selectedAnswers =
                from answer in LocalAppData.Answers
                where answer.AnswersDate.Date >= dateTimePickerFromDate.Value.Date &&
                      answer.AnswersDate.Date <= dateTimePickerToDate.Value.Date
                select answer;

            foreach (var answer in selectedAnswers)
            {
                selectedAnswerList.Add(answer);
            }

            string[] seriesArray = { "Right answers", "Wrong answers", "Cancelled answers" };
            var pointsArray = LocalAppData.GetAnswersCount(selectedAnswerList);

            this.chart1.Palette = ChartColorPalette.SeaGreen;
            this.chart1.Series.Clear();
          
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
            //throw new NotImplementedException();
        }

        private void dateTimePickerFromDate_ValueChanged(object sender, System.EventArgs e)
        {
            DrawStatistic();
        }

        private void dateTimePickerToDate_ValueChanged(object sender, System.EventArgs e)
        {
            DrawStatistic();
        }
    }
}
