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
            this.SuspendLayout();
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Location = new System.Drawing.Point(123, 27);
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.Size = new System.Drawing.Size(124, 20);
            this.textBoxOriginal.TabIndex = 0;
            // 
            // textBoxRU1
            // 
            this.textBoxRU1.Location = new System.Drawing.Point(123, 84);
            this.textBoxRU1.Name = "textBoxRU1";
            this.textBoxRU1.Size = new System.Drawing.Size(124, 20);
            this.textBoxRU1.TabIndex = 1;
            // 
            // textBoxRU2
            // 
            this.textBoxRU2.Enabled = false;
            this.textBoxRU2.Location = new System.Drawing.Point(123, 112);
            this.textBoxRU2.Name = "textBoxRU2";
            this.textBoxRU2.Size = new System.Drawing.Size(124, 20);
            this.textBoxRU2.TabIndex = 2;
            // 
            // textBoxRU3
            // 
            this.textBoxRU3.Enabled = false;
            this.textBoxRU3.Location = new System.Drawing.Point(123, 140);
            this.textBoxRU3.Name = "textBoxRU3";
            this.textBoxRU3.Size = new System.Drawing.Size(124, 20);
            this.textBoxRU3.TabIndex = 3;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(123, 55);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(124, 21);
            this.comboBoxCategories.TabIndex = 4;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(90, 209);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(172, 209);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddTranslate
            // 
            this.buttonAddTranslate.Location = new System.Drawing.Point(158, 166);
            this.buttonAddTranslate.Name = "buttonAddTranslate";
            this.buttonAddTranslate.Size = new System.Drawing.Size(89, 23);
            this.buttonAddTranslate.TabIndex = 7;
            this.buttonAddTranslate.Text = "Add translate";
            this.buttonAddTranslate.UseVisualStyleBackColor = true;
            this.buttonAddTranslate.Click += new System.EventHandler(this.buttonAddTranslate_Click);
            // 
            // UpdatingWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 244);
            this.Controls.Add(this.buttonAddTranslate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.textBoxRU3);
            this.Controls.Add(this.textBoxRU2);
            this.Controls.Add(this.textBoxRU1);
            this.Controls.Add(this.textBoxOriginal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatingWord";
            this.Text = "UpdatingWord";
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
    }
}