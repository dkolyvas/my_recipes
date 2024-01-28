namespace MyRecipies.Controls
{
    partial class RecipeShowControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtCategory = new TextBox();
            txtPosition = new TextBox();
            chckFavorite = new CheckBox();
            chckImplemented = new CheckBox();
            btnEdit = new Button();
            chckSelect = new CheckBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(9, 6);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(300, 27);
            txtName.TabIndex = 0;
            // 
            // txtCategory
            // 
            txtCategory.Enabled = false;
            txtCategory.Location = new Point(335, 6);
            txtCategory.Name = "txtCategory";
            txtCategory.ReadOnly = true;
            txtCategory.Size = new Size(180, 27);
            txtCategory.TabIndex = 1;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(549, 6);
            txtPosition.Name = "txtPosition";
            txtPosition.ReadOnly = true;
            txtPosition.Size = new Size(93, 27);
            txtPosition.TabIndex = 2;
            // 
            // chckFavorite
            // 
            chckFavorite.AutoSize = true;
            chckFavorite.Enabled = false;
            chckFavorite.Location = new Point(675, 12);
            chckFavorite.Name = "chckFavorite";
            chckFavorite.Size = new Size(18, 17);
            chckFavorite.TabIndex = 3;
            chckFavorite.UseVisualStyleBackColor = true;
            // 
            // chckImplemented
            // 
            chckImplemented.AutoSize = true;
            chckImplemented.Enabled = false;
            chckImplemented.Location = new Point(768, 12);
            chckImplemented.Name = "chckImplemented";
            chckImplemented.Size = new Size(18, 17);
            chckImplemented.TabIndex = 4;
            chckImplemented.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ButtonShadow;
            btnEdit.Location = new Point(818, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(111, 31);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Εμφάνιση";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // chckSelect
            // 
            chckSelect.AutoSize = true;
            chckSelect.Location = new Point(948, 11);
            chckSelect.Name = "chckSelect";
            chckSelect.Size = new Size(18, 17);
            chckSelect.TabIndex = 6;
            chckSelect.UseVisualStyleBackColor = true;
            chckSelect.CheckedChanged += chckSelect_CheckedChanged;
            // 
            // RecipeShowControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(chckSelect);
            Controls.Add(btnEdit);
            Controls.Add(chckImplemented);
            Controls.Add(chckFavorite);
            Controls.Add(txtPosition);
            Controls.Add(txtCategory);
            Controls.Add(txtName);
            Name = "RecipeShowControl";
            Size = new Size(1027, 40);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtCategory;
        private TextBox txtPosition;
        private CheckBox chckFavorite;
        private CheckBox chckImplemented;
        private Button btnEdit;
        private CheckBox chckSelect;
    }
}
