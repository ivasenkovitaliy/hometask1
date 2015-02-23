namespace HomeTask_WindowsForms
{
    partial class WordsManagement
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
            this.comboBoxSelectCategoryForSearching = new System.Windows.Forms.ComboBox();
            this.textBoxWordForSearching = new System.Windows.Forms.TextBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonAddWord = new System.Windows.Forms.Button();
            this.buttonEditWord = new System.Windows.Forms.Button();
            this.buttonFormClose = new System.Windows.Forms.Button();
            this.buttonDeleteWord = new System.Windows.Forms.Button();
            this.dataGridViewWordsManagement = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.translateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceWordsManagement = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWordsManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWordsManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectCategoryForSearching
            // 
            this.comboBoxSelectCategoryForSearching.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comboBoxSelectCategoryForSearching.FormattingEnabled = true;
            this.comboBoxSelectCategoryForSearching.Location = new System.Drawing.Point(12, 36);
            this.comboBoxSelectCategoryForSearching.Name = "comboBoxSelectCategoryForSearching";
            this.comboBoxSelectCategoryForSearching.Size = new System.Drawing.Size(158, 21);
            this.comboBoxSelectCategoryForSearching.TabIndex = 0;
            this.comboBoxSelectCategoryForSearching.Text = "Select Category";
            this.comboBoxSelectCategoryForSearching.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectCategoryForSearching_SelectedIndexChanged);
            // 
            // textBoxWordForSearching
            // 
            this.textBoxWordForSearching.Location = new System.Drawing.Point(176, 37);
            this.textBoxWordForSearching.Name = "textBoxWordForSearching";
            this.textBoxWordForSearching.Size = new System.Drawing.Size(210, 20);
            this.textBoxWordForSearching.TabIndex = 1;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(398, 36);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 2;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.Location = new System.Drawing.Point(12, 299);
            this.buttonAddWord.Name = "buttonAddWord";
            this.buttonAddWord.Size = new System.Drawing.Size(75, 23);
            this.buttonAddWord.TabIndex = 4;
            this.buttonAddWord.Text = "Add";
            this.buttonAddWord.UseVisualStyleBackColor = true;
            this.buttonAddWord.Click += new System.EventHandler(this.buttonAddWord_Click);
            // 
            // buttonEditWord
            // 
            this.buttonEditWord.Location = new System.Drawing.Point(94, 299);
            this.buttonEditWord.Name = "buttonEditWord";
            this.buttonEditWord.Size = new System.Drawing.Size(75, 23);
            this.buttonEditWord.TabIndex = 5;
            this.buttonEditWord.Text = "Update";
            this.buttonEditWord.UseVisualStyleBackColor = true;
            this.buttonEditWord.Click += new System.EventHandler(this.buttonEditWord_Click);
            // 
            // buttonFormClose
            // 
            this.buttonFormClose.Location = new System.Drawing.Point(397, 298);
            this.buttonFormClose.Name = "buttonFormClose";
            this.buttonFormClose.Size = new System.Drawing.Size(75, 23);
            this.buttonFormClose.TabIndex = 6;
            this.buttonFormClose.Text = "Close";
            this.buttonFormClose.UseVisualStyleBackColor = true;
            this.buttonFormClose.Click += new System.EventHandler(this.buttonFormClose_Click);
            // 
            // buttonDeleteWord
            // 
            this.buttonDeleteWord.Location = new System.Drawing.Point(175, 298);
            this.buttonDeleteWord.Name = "buttonDeleteWord";
            this.buttonDeleteWord.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteWord.TabIndex = 7;
            this.buttonDeleteWord.Text = "Remove";
            this.buttonDeleteWord.UseVisualStyleBackColor = true;
            this.buttonDeleteWord.Click += new System.EventHandler(this.buttonDeleteWord_Click);
            // 
            // dataGridViewWordsManagement
            // 
            this.dataGridViewWordsManagement.AllowUserToAddRows = false;
            this.dataGridViewWordsManagement.AllowUserToDeleteRows = false;
            this.dataGridViewWordsManagement.AllowUserToResizeColumns = false;
            this.dataGridViewWordsManagement.AllowUserToResizeRows = false;
            this.dataGridViewWordsManagement.AutoGenerateColumns = false;
            this.dataGridViewWordsManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWordsManagement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.originalDataGridViewTextBoxColumn,
            this.translateDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn});
            this.dataGridViewWordsManagement.DataSource = this.bindingSourceWordsManagement;
            this.dataGridViewWordsManagement.Location = new System.Drawing.Point(12, 65);
            this.dataGridViewWordsManagement.MultiSelect = false;
            this.dataGridViewWordsManagement.Name = "dataGridViewWordsManagement";
            this.dataGridViewWordsManagement.ReadOnly = true;
            this.dataGridViewWordsManagement.RowHeadersVisible = false;
            this.dataGridViewWordsManagement.Size = new System.Drawing.Size(460, 214);
            this.dataGridViewWordsManagement.TabIndex = 8;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "#";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 40;
            // 
            // originalDataGridViewTextBoxColumn
            // 
            this.originalDataGridViewTextBoxColumn.DataPropertyName = "Original";
            this.originalDataGridViewTextBoxColumn.HeaderText = "Original";
            this.originalDataGridViewTextBoxColumn.Name = "originalDataGridViewTextBoxColumn";
            this.originalDataGridViewTextBoxColumn.ReadOnly = true;
            this.originalDataGridViewTextBoxColumn.Width = 130;
            // 
            // translateDataGridViewTextBoxColumn
            // 
            this.translateDataGridViewTextBoxColumn.DataPropertyName = "Translate";
            this.translateDataGridViewTextBoxColumn.HeaderText = "Translate";
            this.translateDataGridViewTextBoxColumn.Name = "translateDataGridViewTextBoxColumn";
            this.translateDataGridViewTextBoxColumn.ReadOnly = true;
            this.translateDataGridViewTextBoxColumn.Width = 140;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Width = 130;
            // 
            // bindingSourceWordsManagement
            // 
            this.bindingSourceWordsManagement.DataSource = typeof(HomeTask_WindowsForms.Word);
            // 
            // WordsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 334);
            this.Controls.Add(this.dataGridViewWordsManagement);
            this.Controls.Add(this.buttonDeleteWord);
            this.Controls.Add(this.buttonFormClose);
            this.Controls.Add(this.buttonEditWord);
            this.Controls.Add(this.buttonAddWord);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.textBoxWordForSearching);
            this.Controls.Add(this.comboBoxSelectCategoryForSearching);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WordsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordsManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWordsManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWordsManagement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelectCategoryForSearching;
        private System.Windows.Forms.TextBox textBoxWordForSearching;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonAddWord;
        private System.Windows.Forms.Button buttonEditWord;
        private System.Windows.Forms.Button buttonFormClose;
        private System.Windows.Forms.Button buttonDeleteWord;
        private System.Windows.Forms.DataGridView dataGridViewWordsManagement;
        private System.Windows.Forms.BindingSource bindingSourceWordsManagement;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn translateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;

    }
}