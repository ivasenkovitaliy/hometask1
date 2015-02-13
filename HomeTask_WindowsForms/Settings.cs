using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            domainUpDownTimeInterval.Text = ( (LocalRepository.TimerForShowingTestWindow.Interval)/ 60000).ToString();

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
            
            foreach (var category in LocalRepository.Categories)
            {
                dataGridViewSettings.Rows.Add(category.GetCategory, category.IsUsed);
            }
            
            this.Closing += Settings_Closing;
        }

        void Settings_Closing(object sender, CancelEventArgs e)
        {
            LocalRepository.TimerForShowingTestWindow.Start();
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
            LocalRepository.TimerForShowingTestWindow.Interval = Convert.ToInt16(domainUpDownTimeInterval.Text) * 60000;
            this.Close();
        }

        private void dataGridViewSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Category> tempCategories = LocalRepository.Categories.ToList();
            tempCategories[e.RowIndex].ChangeIsUsed();
            LocalRepository.Categories.Clear();
            LocalRepository.Categories = new HashSet<Category>(tempCategories);
        }

        private void buttonCancel_PanelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
