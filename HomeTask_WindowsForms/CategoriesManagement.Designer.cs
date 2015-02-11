namespace HomeTask_WindowsForms
{
    partial class CategoriesManagement
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
            this.dataGridViewCategoriesManagement = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.textBoxNewCategoryName = new System.Windows.Forms.TextBox();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.buttonUpdateCategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoriesManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCategoriesManagement
            // 
            this.dataGridViewCategoriesManagement.AllowUserToAddRows = false;
            this.dataGridViewCategoriesManagement.AllowUserToDeleteRows = false;
            this.dataGridViewCategoriesManagement.AllowUserToResizeColumns = false;
            this.dataGridViewCategoriesManagement.AllowUserToResizeRows = false;
            this.dataGridViewCategoriesManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategoriesManagement.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCategoriesManagement.MultiSelect = false;
            this.dataGridViewCategoriesManagement.Name = "dataGridViewCategoriesManagement";
            this.dataGridViewCategoriesManagement.RowHeadersVisible = false;
            this.dataGridViewCategoriesManagement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCategoriesManagement.Size = new System.Drawing.Size(296, 180);
            this.dataGridViewCategoriesManagement.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 230);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(65, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add new";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(233, 230);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // textBoxNewCategoryName
            // 
            this.textBoxNewCategoryName.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxNewCategoryName.Location = new System.Drawing.Point(13, 202);
            this.textBoxNewCategoryName.Name = "textBoxNewCategoryName";
            this.textBoxNewCategoryName.Size = new System.Drawing.Size(236, 20);
            this.textBoxNewCategoryName.TabIndex = 4;
            this.textBoxNewCategoryName.Text = "enter new category/category name name here";
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Enabled = false;
            this.buttonDeleteCategory.Location = new System.Drawing.Point(166, 230);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(61, 23);
            this.buttonDeleteCategory.TabIndex = 5;
            this.buttonDeleteCategory.Text = "Remove";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // buttonUpdateCategory
            // 
            this.buttonUpdateCategory.Enabled = false;
            this.buttonUpdateCategory.Location = new System.Drawing.Point(86, 230);
            this.buttonUpdateCategory.Name = "buttonUpdateCategory";
            this.buttonUpdateCategory.Size = new System.Drawing.Size(74, 23);
            this.buttonUpdateCategory.TabIndex = 6;
            this.buttonUpdateCategory.Text = "Update";
            this.buttonUpdateCategory.UseVisualStyleBackColor = true;
            this.buttonUpdateCategory.Click += new System.EventHandler(this.buttonUpdateCategory_Click);
            // 
            // CategoriesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 262);
            this.Controls.Add(this.buttonUpdateCategory);
            this.Controls.Add(this.buttonDeleteCategory);
            this.Controls.Add(this.textBoxNewCategoryName);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.dataGridViewCategoriesManagement);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoriesManagement";
            this.Text = "CategoriesManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoriesManagement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCategoriesManagement;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox textBoxNewCategoryName;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.Button buttonUpdateCategory;

    }
}