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
            this.PanelSetttings = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCancel_PanelSettings = new System.Windows.Forms.Button();
            this.buttonSubmit_PanelSettings = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelSetttings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSetttings
            // 
            this.PanelSetttings.Controls.Add(this.label1);
            this.PanelSetttings.Controls.Add(this.dataGridView1);
            this.PanelSetttings.Controls.Add(this.buttonCancel_PanelSettings);
            this.PanelSetttings.Controls.Add(this.buttonSubmit_PanelSettings);
            this.PanelSetttings.Controls.Add(this.domainUpDown1);
            this.PanelSetttings.Controls.Add(this.label2);
            this.PanelSetttings.Location = new System.Drawing.Point(10, 12);
            this.PanelSetttings.Name = "PanelSetttings";
            this.PanelSetttings.Size = new System.Drawing.Size(303, 239);
            this.PanelSetttings.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(24, 76);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(240, 120);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("20");
            this.domainUpDown1.Items.Add("19");
            this.domainUpDown1.Items.Add("18");
            this.domainUpDown1.Items.Add("17");
            this.domainUpDown1.Items.Add("16");
            this.domainUpDown1.Items.Add("15");
            this.domainUpDown1.Items.Add("14");
            this.domainUpDown1.Items.Add("13");
            this.domainUpDown1.Items.Add("12");
            this.domainUpDown1.Items.Add("11");
            this.domainUpDown1.Items.Add("10");
            this.domainUpDown1.Items.Add("9");
            this.domainUpDown1.Items.Add("8");
            this.domainUpDown1.Items.Add("7");
            this.domainUpDown1.Items.Add("6");
            this.domainUpDown1.Items.Add("5");
            this.domainUpDown1.Items.Add("4");
            this.domainUpDown1.Items.Add("3");
            this.domainUpDown1.Items.Add("2");
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Location = new System.Drawing.Point(154, 24);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(47, 20);
            this.domainUpDown1.TabIndex = 1;
            this.domainUpDown1.Text = "3";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose category of words to test";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 262);
            this.Controls.Add(this.PanelSetttings);
            this.Name = "Settings";
            this.Text = "Settings";
            this.PanelSetttings.ResumeLayout(false);
            this.PanelSetttings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelSetttings;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCancel_PanelSettings;
        private System.Windows.Forms.Button buttonSubmit_PanelSettings;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}