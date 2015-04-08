using System;
using System.ComponentModel;
using System.Windows.Forms;
using EnglishAssistant.DAL;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;

namespace EnglishAssistant.Forms
{
    public partial class Settings : Form
    {
        readonly private CategoryRepository _categoryRepository = new CategoryRepository();
        public Settings()
        {
            InitializeComponent();

            domainUpDownTimeInterval.Text = ((LocalAppData.Instance.TimerForShowingTestWindow.Interval) / 60000).ToString();

            PrepareForm();

            Closing += Settings_Closing;
        }

        private void PrepareForm()
        {
            bindingSourceCategoryToUse.ResetBindings(true);
            bindingSourceCategoryToUse.DataSource = LocalAppData.Instance.Categories;

            dataGridViewSettings.ClearSelection(); // remove selection from first row
        }

        void Settings_Closing(object sender, CancelEventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Start();
        }

        private void buttonSubmit_PanelSettings_Click(object sender, EventArgs e)
        {
            LocalAppData.Instance.TimerForShowingTestWindow.Interval = Convert.ToInt16(domainUpDownTimeInterval.Text) * 60000;

            Properties.Settings.Default.TestTimerInterval = LocalAppData.Instance.TimerForShowingTestWindow.Interval;
            Properties.Settings.Default.Save();

            Close();
        }

        private void dataGridViewSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSettings.CurrentRow != null)
            {
                var categoryToChangeUse = (Category)dataGridViewSettings.CurrentRow.DataBoundItem;

                _categoryRepository.ChangeUsingCategory(categoryToChangeUse);

                var indexOfCategoriesList = LocalAppData.Instance.Categories.IndexOf(categoryToChangeUse);
                LocalAppData.Instance.Categories[indexOfCategoriesList].IsUsed =
                    !LocalAppData.Instance.Categories[indexOfCategoriesList].IsUsed;
            }

            PrepareForm();
        }

        private void buttonCancel_PanelSettings_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
