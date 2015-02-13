using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeTask_WindowsForms
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
            DrawStatistic();
            
            this.FormClosing += Statistic_FormClosing;
        }

        void Statistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Start();
            //throw new NotImplementedException();
        }

        private void DrawStatistic()
        {
            string[] seriesArray = { "Right answers", "Wrong answers" };
            int[] pointsArray = { Answers.RightAnswers, Answers.WrongAnswers};

            // Set palette.
            this.chart1.Palette = ChartColorPalette.SeaGreen;
            var ser = this.chart1.Series.FindByName("Series1");
            ser.Name = "Your answers";
            
            // Set title.
            this.chart1.Titles.Add("Answers");

            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
            //throw new NotImplementedException();
        }
    }
}
