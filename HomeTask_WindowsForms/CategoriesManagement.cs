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
    public partial class CategoriesManagement : Form
    {
        readonly private MainForm _parentForm;
        public CategoriesManagement(MainForm parentform)
        {
            InitializeComponent();
            _parentForm = parentform;

            this.Closing += WordsManagment_Closing;
        }

        void WordsManagment_Closing(object sender, CancelEventArgs e)
        {
            _parentForm.TimerToShowTestWindow.Start();
            //throw new NotImplementedException();
        }
    }
}
