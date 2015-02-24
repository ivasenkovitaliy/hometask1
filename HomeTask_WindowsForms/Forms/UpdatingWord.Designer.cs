namespace HomeTask_WindowsForms
{
    partial class UpdatingWord
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
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.textBoxRU1 = new System.Windows.Forms.TextBox();
            this.textBoxRU2 = new System.Windows.Forms.TextBox();
            this.textBoxRU3 = new System.Windows.Forms.TextBox();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddTranslate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRemoveTranslate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Location = new System.Drawing.Point(3, 4);
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.Size = new System.Drawing.Size(124, 20);
            this.textBoxOriginal.TabIndex = 0;
            // 
            // textBoxRU1
            // 
            this.textBoxRU1.Location = new System.Drawing.Point(3, 61);
            this.textBoxRU1.Name = "textBoxRU1";
            this.textBoxRU1.Size = new System.Drawing.Size(124, 20);
            this.textBoxRU1.TabIndex = 1;
            // 
            // textBoxRU2
            // 
            this.textBoxRU2.Enabled = false;
            this.textBoxRU2.Location = new System.Drawing.Point(3, 89);
            this.textBoxRU2.Name = "textBoxRU2";
            this.textBoxRU2.Size = new System.Drawing.Size(124, 20);
            this.textBoxRU2.TabIndex = 2;
            // 
            // textBoxRU3
            // 
            this.textBoxRU3.Enabled = false;
            this.textBoxRU3.Location = new System.Drawing.Point(3, 117);
            this.textBoxRU3.Name = "textBoxRU3";
            this.textBoxRU3.Size = new System.Drawing.Size(124, 20);
            this.textBoxRU3.TabIndex = 3;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(3, 32);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(124, 21);
            this.comboBoxCategories.TabIndex = 4;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(90, 211);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(172, 211);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddTranslate
            // 
            this.buttonAddTranslate.Location = new System.Drawing.Point(19, 166);
            this.buttonAddTranslate.Name = "buttonAddTranslate";
            this.buttonAddTranslate.Size = new System.Drawing.Size(107, 23);
            this.buttonAddTranslate.TabIndex = 7;
            this.buttonAddTranslate.Text = "Add translate";
            this.buttonAddTranslate.UseVisualStyleBackColor = true;
            this.buttonAddTranslate.Click += new System.EventHandler(this.buttonAddTranslate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxRU2);
            this.panel1.Controls.Add(this.textBoxOriginal);
            this.panel1.Controls.Add(this.textBoxRU1);
            this.panel1.Controls.Add(this.textBoxRU3);
            this.panel1.Controls.Add(this.comboBoxCategories);
            this.panel1.Location = new System.Drawing.Point(119, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 141);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "RU#1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "RU#2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "RU#3";
            // 
            // buttonRemoveTranslate
            // 
            this.buttonRemoveTranslate.Location = new System.Drawing.Point(140, 166);
            this.buttonRemoveTranslate.Name = "buttonRemoveTranslate";
            this.buttonRemoveTranslate.Size = new System.Drawing.Size(107, 23);
            this.buttonRemoveTranslate.TabIndex = 14;
            this.buttonRemoveTranslate.Text = "Remove Translate";
            this.buttonRemoveTranslate.UseVisualStyleBackColor = true;
            this.buttonRemoveTranslate.Click += new System.EventHandler(this.buttonRemoveTranslate_Click);
            // 
            // UpdatingWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 242);
            this.Controls.Add(this.buttonRemoveTranslate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAddTranslate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUpdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatingWord";
            this.Text = "UpdatingWord";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.TextBox textBoxRU1;
        private System.Windows.Forms.TextBox textBoxRU2;
        private System.Windows.Forms.TextBox textBoxRU3;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddTranslate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonRemoveTranslate;
    }
}