using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public partial class Settings : Form
    {
        readonly private CategoryRepository _categoryRepository = new CategoryRepository();
        public Settings()
        {
            InitializeComponent();
            
            domainUpDownTimeInterval.Text = ( (LocalAppData.TimerForShowingTestWindow.Interval)/ 60000).ToString();

            DrawTable();
            
            this.Closing += Settings_Closing;
        }

        private void DrawTable()
        {
            LocalAppData.Categories = _categoryRepository.GetAllCategories();
            
            bindingSourceCategoryToUse.Clear();
            foreach (var category in LocalAppData.Categories)
            {
                bindingSourceCategoryToUse.Add(category);
            }

            dataGridViewSettings.ClearSelection(); // remove selection from first row
            //throw new NotImplementedException();
        }

        void Settings_Closing(object sender, CancelEventArgs e)
        {
            LocalAppData.TimerForShowingTestWindow.Start();
            //throw new NotImplementedException();
        }

        private void buttonSubmit_PanelSettings_Click(object sender, EventArgs e)
        {
            LocalAppData.TimerForShowingTestWindow.Interval = Convert.ToInt16(domainUpDownTimeInterval.Text) * 60000;

            Properties.Settings.Default.TestTimerInterval = LocalAppData.TimerForShowingTestWindow.Interval;
            Properties.Settings.Default.Save();
            
            this.Close();
        }

        private void dataGridViewSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var changingCategory = LocalAppData.GetCategoryWithCategoryName(dataGridViewSettings.CurrentRow.Cells[0].Value.ToString());
            
            _categoryRepository.ChangeUsingCategory(changingCategory.CategoryId, !changingCategory.IsUsed);
            
            DrawTable();
        }

        private void buttonCancel_PanelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
