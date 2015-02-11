using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class Settings : Form
    {
        readonly private MainForm _parentForm;
       
        public Settings(MainForm parentform)
        {
            InitializeComponent();
            _parentForm = parentform;
            domainUpDownTimeInterval.Text = (parentform.TestInterval/60000).ToString();

            // making first column
            DataGridViewColumn columnCategoryName = new DataGridViewTextBoxColumn();
            {
                columnCategoryName.CellTemplate = new DataGridViewTextBoxCell();
                columnCategoryName.ReadOnly = true;
                columnCategoryName.Width = 187;
            }

            // making second column
            DataGridViewCheckBoxColumn columnCheckBox = new DataGridViewCheckBoxColumn();
            {
                columnCheckBox.CellTemplate = new DataGridViewCheckBoxCell();
                columnCheckBox.Width = 50;
            }

            dataGridViewSettings.SelectionChanged += dataGridViewSettings_SelectionChanged; // using for cleaning cursor in datagridview
            dataGridViewSettings.Rows.Clear();   //  cleaning table

            // adding columns
            dataGridViewSettings.Columns.Insert(0, columnCheckBox);
            dataGridViewSettings.Columns.Insert(0, columnCategoryName);

            
            foreach (var category in parentform.Categories)
            {
                dataGridViewSettings.Rows.Add(category.GetCategory, category.GetCategoryUsed());
            }
            
            this.Closing += Settings_Closing;
        }

        void Settings_Closing(object sender, CancelEventArgs e)
        {
            _parentForm.TimerToShowTestWindow.Start();
            //throw new NotImplementedException();
        }

        // using for cleaning cursor in datagridview
        private void dataGridViewSettings_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewSettings.ClearSelection();
            //throw new NotImplementedException();
        }

        private void buttonSubmit_PanelSettings_Click(object sender, EventArgs e)
        {
            _parentForm.TestInterval = Convert.ToInt16(domainUpDownTimeInterval.Text) * 60000;
            this.Close();
        }

        private void dataGridViewSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Category> tempCategories = _parentForm.Categories.ToList();
            tempCategories[e.RowIndex].ChangeIsUsed();
            _parentForm.Categories.Clear();
            _parentForm.Categories = new HashSet<Category>(tempCategories);
        }

        private void buttonCancel_PanelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
