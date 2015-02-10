﻿

using System;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._iconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelWelcome = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelWelcomeNoButton = new System.Windows.Forms.Button();
            this.PanelWelcomeYesButton = new System.Windows.Forms.Button();
            this.WelcomeTextLabel = new System.Windows.Forms.Label();
            this.PanelTest = new System.Windows.Forms.Panel();
            this.buttonAnotherTryNo = new System.Windows.Forms.Button();
            this.buttonAnotherTryYes = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDontSure = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.radioButtonAnswer5 = new System.Windows.Forms.RadioButton();
            this.radioButtonAnswer4 = new System.Windows.Forms.RadioButton();
            this.radioButtonAnswer3 = new System.Windows.Forms.RadioButton();
            this.radioButtonAnswer2 = new System.Windows.Forms.RadioButton();
            this.radioButtonAnswer1 = new System.Windows.Forms.RadioButton();
            this.OriginaWordLabel = new System.Windows.Forms.Label();
            this.CategoryNameLabel = new System.Windows.Forms.Label();
            this.PanelSetttings = new System.Windows.Forms.Panel();
            this.buttonCancel_PanelSettings = new System.Windows.Forms.Button();
            this.buttonSubmit_PanelSettings = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._iconContextMenuStrip.SuspendLayout();
            this.PanelWelcome.SuspendLayout();
            this.PanelTest.SuspendLayout();
            this.PanelSetttings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _notifyIcon
            // 
            this._notifyIcon.ContextMenuStrip = this._iconContextMenuStrip;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "notifyIcon1";
            this._notifyIcon.Visible = true;
            // 
            // _iconContextMenuStrip
            // 
            this._iconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this._iconContextMenuStrip.Name = "contextMenuStrip1";
            this._iconContextMenuStrip.Size = new System.Drawing.Size(121, 70);
            // 
            // тестToolStripMenuItem
            // 
            this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
            this.тестToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.тестToolStripMenuItem.Text = "Start test";
            this.тестToolStripMenuItem.Click += new System.EventHandler(this.тестToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // PanelWelcome
            // 
            this.PanelWelcome.Controls.Add(this.label1);
            this.PanelWelcome.Controls.Add(this.PanelWelcomeNoButton);
            this.PanelWelcome.Controls.Add(this.PanelWelcomeYesButton);
            this.PanelWelcome.Location = new System.Drawing.Point(70, 172);
            this.PanelWelcome.Name = "PanelWelcome";
            this.PanelWelcome.Size = new System.Drawing.Size(191, 92);
            this.PanelWelcome.TabIndex = 1;
            this.PanelWelcome.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start test now?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelWelcomeNoButton
            // 
            this.PanelWelcomeNoButton.Location = new System.Drawing.Point(99, 37);
            this.PanelWelcomeNoButton.Name = "PanelWelcomeNoButton";
            this.PanelWelcomeNoButton.Size = new System.Drawing.Size(75, 23);
            this.PanelWelcomeNoButton.TabIndex = 1;
            this.PanelWelcomeNoButton.Text = "No";
            this.PanelWelcomeNoButton.UseVisualStyleBackColor = true;
            this.PanelWelcomeNoButton.Click += new System.EventHandler(this.FirstLayoutNoButton_Click);
            // 
            // PanelWelcomeYesButton
            // 
            this.PanelWelcomeYesButton.Location = new System.Drawing.Point(18, 37);
            this.PanelWelcomeYesButton.Name = "PanelWelcomeYesButton";
            this.PanelWelcomeYesButton.Size = new System.Drawing.Size(75, 23);
            this.PanelWelcomeYesButton.TabIndex = 0;
            this.PanelWelcomeYesButton.Text = "Yes";
            this.PanelWelcomeYesButton.UseVisualStyleBackColor = true;
            this.PanelWelcomeYesButton.Click += new System.EventHandler(this.FirstLayoutYesButton_Click);
            // 
            // WelcomeTextLabel
            // 
            this.WelcomeTextLabel.AutoSize = true;
            this.WelcomeTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WelcomeTextLabel.Location = new System.Drawing.Point(50, 18);
            this.WelcomeTextLabel.Name = "WelcomeTextLabel";
            this.WelcomeTextLabel.Size = new System.Drawing.Size(225, 24);
            this.WelcomeTextLabel.TabIndex = 2;
            this.WelcomeTextLabel.Text = "Welcome to test program!";
            // 
            // PanelTest
            // 
            this.PanelTest.Controls.Add(this.buttonAnotherTryNo);
            this.PanelTest.Controls.Add(this.buttonAnotherTryYes);
            this.PanelTest.Controls.Add(this.labelResult);
            this.PanelTest.Controls.Add(this.buttonCancel);
            this.PanelTest.Controls.Add(this.buttonDontSure);
            this.PanelTest.Controls.Add(this.buttonSubmit);
            this.PanelTest.Controls.Add(this.radioButtonAnswer5);
            this.PanelTest.Controls.Add(this.radioButtonAnswer4);
            this.PanelTest.Controls.Add(this.radioButtonAnswer3);
            this.PanelTest.Controls.Add(this.radioButtonAnswer2);
            this.PanelTest.Controls.Add(this.radioButtonAnswer1);
            this.PanelTest.Controls.Add(this.OriginaWordLabel);
            this.PanelTest.Controls.Add(this.CategoryNameLabel);
            this.PanelTest.Location = new System.Drawing.Point(12, 8);
            this.PanelTest.Name = "PanelTest";
            this.PanelTest.Size = new System.Drawing.Size(292, 231);
            this.PanelTest.TabIndex = 3;
            this.PanelTest.Visible = false;
            // 
            // buttonAnotherTryNo
            // 
            this.buttonAnotherTryNo.Location = new System.Drawing.Point(169, 192);
            this.buttonAnotherTryNo.Name = "buttonAnotherTryNo";
            this.buttonAnotherTryNo.Size = new System.Drawing.Size(75, 23);
            this.buttonAnotherTryNo.TabIndex = 12;
            this.buttonAnotherTryNo.Text = "No";
            this.buttonAnotherTryNo.UseVisualStyleBackColor = true;
            this.buttonAnotherTryNo.Visible = false;
            this.buttonAnotherTryNo.Click += new System.EventHandler(this.buttonAnotherTryNo_Click);
            // 
            // buttonAnotherTryYes
            // 
            this.buttonAnotherTryYes.Location = new System.Drawing.Point(61, 192);
            this.buttonAnotherTryYes.Name = "buttonAnotherTryYes";
            this.buttonAnotherTryYes.Size = new System.Drawing.Size(75, 23);
            this.buttonAnotherTryYes.TabIndex = 11;
            this.buttonAnotherTryYes.Text = "Yes";
            this.buttonAnotherTryYes.UseVisualStyleBackColor = true;
            this.buttonAnotherTryYes.Visible = false;
            this.buttonAnotherTryYes.Click += new System.EventHandler(this.buttonAnotherTryYes_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.Location = new System.Drawing.Point(128, 113);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(51, 20);
            this.labelResult.TabIndex = 10;
            this.labelResult.Text = "label2";
            this.labelResult.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(217, 192);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(73, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel test";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDontSure
            // 
            this.buttonDontSure.Location = new System.Drawing.Point(101, 192);
            this.buttonDontSure.Name = "buttonDontSure";
            this.buttonDontSure.Size = new System.Drawing.Size(103, 23);
            this.buttonDontSure.TabIndex = 8;
            this.buttonDontSure.Text = "Dont sure...";
            this.buttonDontSure.UseVisualStyleBackColor = true;
            this.buttonDontSure.Click += new System.EventHandler(this.buttonDontSure_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(19, 192);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(69, 23);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonAnswer5
            // 
            this.radioButtonAnswer5.AutoSize = true;
            this.radioButtonAnswer5.Location = new System.Drawing.Point(20, 162);
            this.radioButtonAnswer5.Name = "radioButtonAnswer5";
            this.radioButtonAnswer5.Size = new System.Drawing.Size(85, 17);
            this.radioButtonAnswer5.TabIndex = 6;
            this.radioButtonAnswer5.TabStop = true;
            this.radioButtonAnswer5.Text = "radioButton5";
            this.radioButtonAnswer5.UseVisualStyleBackColor = true;
            this.radioButtonAnswer5.CheckedChanged += new System.EventHandler(this.radioButtonAnswer5_CheckedChanged);
            // 
            // radioButtonAnswer4
            // 
            this.radioButtonAnswer4.AutoSize = true;
            this.radioButtonAnswer4.Location = new System.Drawing.Point(20, 139);
            this.radioButtonAnswer4.Name = "radioButtonAnswer4";
            this.radioButtonAnswer4.Size = new System.Drawing.Size(85, 17);
            this.radioButtonAnswer4.TabIndex = 5;
            this.radioButtonAnswer4.TabStop = true;
            this.radioButtonAnswer4.Text = "radioButton4";
            this.radioButtonAnswer4.UseVisualStyleBackColor = true;
            this.radioButtonAnswer4.CheckedChanged += new System.EventHandler(this.radioButtonAnswer4_CheckedChanged);
            // 
            // radioButtonAnswer3
            // 
            this.radioButtonAnswer3.AutoSize = true;
            this.radioButtonAnswer3.Location = new System.Drawing.Point(20, 116);
            this.radioButtonAnswer3.Name = "radioButtonAnswer3";
            this.radioButtonAnswer3.Size = new System.Drawing.Size(85, 17);
            this.radioButtonAnswer3.TabIndex = 4;
            this.radioButtonAnswer3.TabStop = true;
            this.radioButtonAnswer3.Text = "radioButton3";
            this.radioButtonAnswer3.UseVisualStyleBackColor = true;
            this.radioButtonAnswer3.CheckedChanged += new System.EventHandler(this.radioButtonAnswer3_CheckedChanged);
            // 
            // radioButtonAnswer2
            // 
            this.radioButtonAnswer2.AutoSize = true;
            this.radioButtonAnswer2.Location = new System.Drawing.Point(20, 93);
            this.radioButtonAnswer2.Name = "radioButtonAnswer2";
            this.radioButtonAnswer2.Size = new System.Drawing.Size(85, 17);
            this.radioButtonAnswer2.TabIndex = 3;
            this.radioButtonAnswer2.TabStop = true;
            this.radioButtonAnswer2.Text = "radioButton2";
            this.radioButtonAnswer2.UseVisualStyleBackColor = true;
            this.radioButtonAnswer2.CheckedChanged += new System.EventHandler(this.radioButtonAnswer2_CheckedChanged);
            // 
            // radioButtonAnswer1
            // 
            this.radioButtonAnswer1.AutoSize = true;
            this.radioButtonAnswer1.Location = new System.Drawing.Point(20, 70);
            this.radioButtonAnswer1.Name = "radioButtonAnswer1";
            this.radioButtonAnswer1.Size = new System.Drawing.Size(85, 17);
            this.radioButtonAnswer1.TabIndex = 2;
            this.radioButtonAnswer1.Text = "radioButton1";
            this.radioButtonAnswer1.UseVisualStyleBackColor = true;
            this.radioButtonAnswer1.CheckedChanged += new System.EventHandler(this.radioButtonAnswer1_CheckedChanged);
            // 
            // OriginaWordLabel
            // 
            this.OriginaWordLabel.AutoSize = true;
            this.OriginaWordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OriginaWordLabel.Location = new System.Drawing.Point(20, 34);
            this.OriginaWordLabel.Name = "OriginaWordLabel";
            this.OriginaWordLabel.Size = new System.Drawing.Size(47, 20);
            this.OriginaWordLabel.TabIndex = 1;
            this.OriginaWordLabel.Text = "Word";
            // 
            // CategoryNameLabel
            // 
            this.CategoryNameLabel.AutoSize = true;
            this.CategoryNameLabel.Location = new System.Drawing.Point(17, 11);
            this.CategoryNameLabel.Name = "CategoryNameLabel";
            this.CategoryNameLabel.Size = new System.Drawing.Size(77, 13);
            this.CategoryNameLabel.TabIndex = 0;
            this.CategoryNameLabel.Text = "CategoryName";
            // 
            // PanelSetttings
            // 
            this.PanelSetttings.Controls.Add(this.dataGridView1);
            this.PanelSetttings.Controls.Add(this.buttonCancel_PanelSettings);
            this.PanelSetttings.Controls.Add(this.buttonSubmit_PanelSettings);
            this.PanelSetttings.Controls.Add(this.domainUpDown1);
            this.PanelSetttings.Controls.Add(this.label2);
            this.PanelSetttings.Location = new System.Drawing.Point(15, 11);
            this.PanelSetttings.Name = "PanelSetttings";
            this.PanelSetttings.Size = new System.Drawing.Size(303, 239);
            this.PanelSetttings.TabIndex = 4;
            this.PanelSetttings.Visible = false;
            // 
            // buttonCancel_PanelSettings
            // 
            this.buttonCancel_PanelSettings.Location = new System.Drawing.Point(113, 202);
            this.buttonCancel_PanelSettings.Name = "buttonCancel_PanelSettings";
            this.buttonCancel_PanelSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel_PanelSettings.TabIndex = 3;
            this.buttonCancel_PanelSettings.Text = "close";
            this.buttonCancel_PanelSettings.UseVisualStyleBackColor = true;
            this.buttonCancel_PanelSettings.Click += new System.EventHandler(this.buttonCancel_PanelSettings_Click);
            // 
            // buttonSubmit_PanelSettings
            // 
            this.buttonSubmit_PanelSettings.Location = new System.Drawing.Point(16, 202);
            this.buttonSubmit_PanelSettings.Name = "buttonSubmit_PanelSettings";
            this.buttonSubmit_PanelSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit_PanelSettings.TabIndex = 2;
            this.buttonSubmit_PanelSettings.Text = "submit";
            this.buttonSubmit_PanelSettings.UseVisualStyleBackColor = true;
            this.buttonSubmit_PanelSettings.Click += new System.EventHandler(this.buttonSubmitTestPanel_Click);
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
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 103);
            this.dataGridView1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 262);
            this.ContextMenuStrip = this._iconContextMenuStrip;
            this.Controls.Add(this.PanelSetttings);
            this.Controls.Add(this.WelcomeTextLabel);
            this.Controls.Add(this.PanelTest);
            this.Controls.Add(this.PanelWelcome);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "wordreminder";
            this._iconContextMenuStrip.ResumeLayout(false);
            this.PanelWelcome.ResumeLayout(false);
            this.PanelWelcome.PerformLayout();
            this.PanelTest.ResumeLayout(false);
            this.PanelTest.PerformLayout();
            this.PanelSetttings.ResumeLayout(false);
            this.PanelSetttings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

      

        #endregion

        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private ContextMenuStrip _iconContextMenuStrip;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel PanelWelcome;
        private Button PanelWelcomeNoButton;
        private Button PanelWelcomeYesButton;
        private Label label1;
        private Label WelcomeTextLabel;
        private Panel PanelTest;
        private ToolStripMenuItem тестToolStripMenuItem;
        private Label CategoryNameLabel;
        private Label OriginaWordLabel;
        private RadioButton radioButtonAnswer5;
        private RadioButton radioButtonAnswer4;
        private RadioButton radioButtonAnswer3;
        private RadioButton radioButtonAnswer2;
        private RadioButton radioButtonAnswer1;
        private Button buttonSubmit;
        private Button buttonCancel;
        private Button buttonDontSure;
        private Label labelResult;
        private Button buttonAnotherTryNo;
        private Button buttonAnotherTryYes;
        private Panel PanelSetttings;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label label2;
        private DomainUpDown domainUpDown1;
        private Button buttonSubmit_PanelSettings;
        private Button buttonCancel_PanelSettings;
        private DataGridView dataGridView1;
    }
}
