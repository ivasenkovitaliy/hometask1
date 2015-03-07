using HomeTask_WindowsForms.Entities;

namespace HomeTask_WindowsForms.Forms
{
    partial class AddingWord
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.textBoxRU1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRU2 = new System.Windows.Forms.TextBox();
            this.textBoxRU3 = new System.Windows.Forms.TextBox();
            this.buttonAddNewTranslation = new System.Windows.Forms.Button();
            this.buttonAddWord = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSourceComboCoxCategory = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComboCoxCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "RU";
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Location = new System.Drawing.Point(15, 23);
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.Size = new System.Drawing.Size(152, 20);
            this.textBoxOriginal.TabIndex = 2;
            // 
            // textBoxRU1
            // 
            this.textBoxRU1.Location = new System.Drawing.Point(15, 85);
            this.textBoxRU1.Name = "textBoxRU1";
            this.textBoxRU1.Size = new System.Drawing.Size(152, 20);
            this.textBoxRU1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "RU#2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "RU#3";
            // 
            // textBoxRU2
            // 
            this.textBoxRU2.Enabled = false;
            this.textBoxRU2.Location = new System.Drawing.Point(15, 119);
            this.textBoxRU2.Name = "textBoxRU2";
            this.textBoxRU2.Size = new System.Drawing.Size(152, 20);
            this.textBoxRU2.TabIndex = 8;
            // 
            // textBoxRU3
            // 
            this.textBoxRU3.Enabled = false;
            this.textBoxRU3.Location = new System.Drawing.Point(15, 151);
            this.textBoxRU3.Name = "textBoxRU3";
            this.textBoxRU3.Size = new System.Drawing.Size(152, 20);
            this.textBoxRU3.TabIndex = 9;
            // 
            // buttonAddNewTranslation
            // 
            this.buttonAddNewTranslation.Location = new System.Drawing.Point(20, 203);
            this.buttonAddNewTranslation.Name = "buttonAddNewTranslation";
            this.buttonAddNewTranslation.Size = new System.Drawing.Size(113, 23);
            this.buttonAddNewTranslation.TabIndex = 10;
            this.buttonAddNewTranslation.Text = "Add new translation";
            this.buttonAddNewTranslation.UseVisualStyleBackColor = true;
            this.buttonAddNewTranslation.Click += new System.EventHandler(this.buttonAddNewTranslation_Click);
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.Location = new System.Drawing.Point(252, 203);
            this.buttonAddWord.Name = "buttonAddWord";
            this.buttonAddWord.Size = new System.Drawing.Size(75, 23);
            this.buttonAddWord.TabIndex = 11;
            this.buttonAddWord.Text = "Add";
            this.buttonAddWord.UseVisualStyleBackColor = true;
            this.buttonAddWord.Click += new System.EventHandler(this.buttonAddWord_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(334, 203);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DataSource = this.bindingSourceComboCoxCategory;
            this.comboBoxCategories.DisplayMember = "CategoryName";
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(15, 55);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(152, 21);
            this.comboBoxCategories.TabIndex = 13;
            this.comboBoxCategories.ValueMember = "CategoryId";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxOriginal);
            this.panel1.Controls.Add(this.comboBoxCategories);
            this.panel1.Controls.Add(this.textBoxRU1);
            this.panel1.Controls.Add(this.textBoxRU2);
            this.panel1.Controls.Add(this.textBoxRU3);
            this.panel1.Location = new System.Drawing.Point(93, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 185);
            this.panel1.TabIndex = 14;
            // 
            // bindingSourceComboCoxCategory
            // 
            this.bindingSourceComboCoxCategory.DataSource = typeof(Category);
            // 
            // AddingWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 238);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAddWord);
            this.Controls.Add(this.buttonAddNewTranslation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddingWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddingWord";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComboCoxCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.TextBox textBoxRU1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRU2;
        private System.Windows.Forms.TextBox textBoxRU3;
        private System.Windows.Forms.Button buttonAddNewTranslation;
        private System.Windows.Forms.Button buttonAddWord;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSourceComboCoxCategory;
    }
}