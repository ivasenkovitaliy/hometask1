using HomeTask_WindowsForms.Infrastructure;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeTask_WindowsForms.Forms
{
    public partial class Statistic : Form
    {
        private readonly StatisticService _statisticService = new StatisticService();

        public Statistic()
        {
            InitializeComponent();
            
            DrawStatistic();
            
            this.FormClosing += Statistic_FormClosing;
        }

        void Statistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Start();
        }

        private void DrawStatistic()
        {
            string[] seriesArray = { "Right answers", "Wrong answers", "Cancelled answers" };
            
            var points = _statisticService.GetAnswersCount(dateTimePickerFromDate.Value.Date, dateTimePickerToDate.Value.Date);
            var pointsArray = new [] {points.Item1, points.Item2, points.Item3};

            chart1.Palette = ChartColorPalette.SeaGreen;
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

            for (var i = 0; i < seriesArray.Length; i++)
            {
                var series = chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);

                chart1.Series[i].IsValueShownAsLabel = true;
            }
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
