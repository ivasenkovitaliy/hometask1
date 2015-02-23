namespace HomeTask_WindowsForms
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PanelSetttings = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSettings = new System.Windows.Forms.DataGridView();
            this.buttonCancel_PanelSettings = new System.Windows.Forms.Button();
            this.buttonSubmit_PanelSettings = new System.Windows.Forms.Button();
            this.domainUpDownTimeInterval = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSourceCategoryToUse = new System.Windows.Forms.BindingSource(this.components);
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUsedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PanelSetttings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCategoryToUse)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSetttings
            // 
            this.PanelSetttings.Controls.Add(this.label1);
            this.PanelSetttings.Controls.Add(this.dataGridViewSettings);
            this.PanelSetttings.Controls.Add(this.buttonCancel_PanelSettings);
            this.PanelSetttings.Controls.Add(this.buttonSubmit_PanelSettings);
            this.PanelSetttings.Controls.Add(this.domainUpDownTimeInterval);
            this.PanelSetttings.Controls.Add(this.label2);
            this.PanelSetttings.Location = new System.Drawing.Point(10, 12);
            this.PanelSetttings.Name = "PanelSetttings";
            this.PanelSetttings.Size = new System.Drawing.Size(303, 239);
            this.PanelSetttings.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose category of words to test";
            // 
            // dataGridViewSettings
            // 
            this.dataGridViewSettings.AllowUserToAddRows = false;
            this.dataGridViewSettings.AllowUserToDeleteRows = false;
            this.dataGridViewSettings.AllowUserToResizeColumns = false;
            this.dataGridViewSettings.AllowUserToResizeRows = false;
            this.dataGridViewSettings.AutoGenerateColumns = false;
            this.dataGridViewSettings.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewSettings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSettings.ColumnHeadersVisible = false;
            this.dataGridViewSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryNameDataGridViewTextBoxColumn,
            this.isUsedDataGridViewCheckBoxColumn});
            this.dataGridViewSettings.DataSource = this.bindingSourceCategoryToUse;
            this.dataGridViewSettings.Location = new System.Drawing.Point(24, 76);
            this.dataGridViewSettings.MultiSelect = false;
            this.dataGridViewSettings.Name = "dataGridViewSettings";
            this.dataGridViewSettings.RowHeadersVisible = false;
            this.dataGridViewSettings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewSettings.Size = new System.Drawing.Size(250, 120);
            this.dataGridViewSettings.TabIndex = 4;
            this.dataGridViewSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSettings_CellContentClick);
            // 
            // buttonCancel_PanelSettings
            // 
            this.buttonCancel_PanelSettings.Location = new System.Drawing.Point(109, 202);
            this.buttonCancel_PanelSettings.Name = "buttonCancel_PanelSettings";
            this.buttonCancel_PanelSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel_PanelSettings.TabIndex = 3;
            this.buttonCancel_PanelSettings.Text = "close";
            this.buttonCancel_PanelSettings.UseVisualStyleBackColor = true;
            this.buttonCancel_PanelSettings.Click += new System.EventHandler(this.buttonCancel_PanelSettings_Click);
            // 
            // buttonSubmit_PanelSettings
            // 
            this.buttonSubmit_PanelSettings.Location = new System.Drawing.Point(24, 202);
            this.buttonSubmit_PanelSettings.Name = "buttonSubmit_PanelSettings";
            this.buttonSubmit_PanelSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit_PanelSettings.TabIndex = 2;
            this.buttonSubmit_PanelSettings.Text = "submit";
            this.buttonSubmit_PanelSettings.UseVisualStyleBackColor = true;
            this.buttonSubmit_PanelSettings.Click += new System.EventHandler(this.buttonSubmit_PanelSettings_Click);
            // 
            // domainUpDownTimeInterval
            // 
            this.domainUpDownTimeInterval.Items.Add("20");
            this.domainUpDownTimeInterval.Items.Add("19");
            this.domainUpDownTimeInterval.Items.Add("18");
            this.domainUpDownTimeInterval.Items.Add("17");
            this.domainUpDownTimeInterval.Items.Add("16");
            this.domainUpDownTimeInterval.Items.Add("15");
            this.domainUpDownTimeInterval.Items.Add("14");
            this.domainUpDownTimeInterval.Items.Add("13");
            this.domainUpDownTimeInterval.Items.Add("12");
            this.domainUpDownTimeInterval.Items.Add("11");
            this.domainUpDownTimeInterval.Items.Add("10");
            this.domainUpDownTimeInterval.Items.Add("9");
            this.domainUpDownTimeInterval.Items.Add("8");
            this.domainUpDownTimeInterval.Items.Add("7");
            this.domainUpDownTimeInterval.Items.Add("6");
            this.domainUpDownTimeInterval.Items.Add("5");
            this.domainUpDownTimeInterval.Items.Add("4");
            this.domainUpDownTimeInterval.Items.Add("3");
            this.domainUpDownTimeInterval.Items.Add("2");
            this.domainUpDownTimeInterval.Items.Add("1");
            this.domainUpDownTimeInterval.Location = new System.Drawing.Point(154, 24);
            this.domainUpDownTimeInterval.Name = "domainUpDownTimeInterval";
            this.domainUpDownTimeInterval.Size = new System.Drawing.Size(47, 20);
            this.domainUpDownTimeInterval.TabIndex = 1;
            this.domainUpDownTimeInterval.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time interval (minutes)";
            // 
            // bindingSourceCategoryToUse
            // 
            this.bindingSourceCategoryToUse.DataSource = typeof(HomeTask_WindowsForms.Category);
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            this.categoryNameDataGridViewTextBoxColumn.Width = 130;
            // 
            // isUsedDataGridViewCheckBoxColumn
            // 
            this.isUsedDataGridViewCheckBoxColumn.DataPropertyName = "IsUsed";
            this.isUsedDataGridViewCheckBoxColumn.HeaderText = "IsUsed";
            this.isUsedDataGridViewCheckBoxColumn.Name = "isUsedDataGridViewCheckBoxColumn";
            this.isUsedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 262);
            this.Controls.Add(this.PanelSetttings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.PanelSetttings.ResumeLayout(false);
            this.PanelSetttings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCategoryToUse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelSetttings;
        private System.Windows.Forms.DataGridView dataGridViewSettings;
        private System.Windows.Forms.Button buttonCancel_PanelSettings;
        private System.Windows.Forms.Button buttonSubmit_PanelSettings;
        private System.Windows.Forms.DomainUpDown domainUpDownTimeInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSourceCategoryToUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUsedDataGridViewCheckBoxColumn;

    }
}