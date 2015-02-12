using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeTask_WindowsForms
{
    public partial class Statistic : Form
    {
        private int _writeAnswers;
        private int _wrongAnswers;

        public Statistic()
        {
            InitializeComponent();
            
            string[] seriesArray = { "Right", "Wrong" };
            var answers = AnswersRepository.GetAnswers();
            
            foreach (var answer in answers)
            {
                if (answer.AnswerValue == true)
                    _writeAnswers++;
                else
                    _wrongAnswers++;
            }
            int[] pointsArray = { _writeAnswers, _wrongAnswers };

            // Set palette.
            this.chart1.Palette = ChartColorPalette.SeaGreen;
            
            // Set title.
            this.chart1.Titles.Add("Answers");

            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }


        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
