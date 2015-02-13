using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class WordsManagement : Form
    {
        public WordsManagement()
        {
            InitializeComponent();

            this.FormClosing += WordsManagement_FormClosing;
        }

        void WordsManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Start();
            //throw new NotImplementedException();
        }
    }
}
