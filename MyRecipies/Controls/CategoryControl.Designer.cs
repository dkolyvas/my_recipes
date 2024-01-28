namespace MyRecipies.Controls
{
    partial class CategoryControl
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
            btnUpdate = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(40, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(279, 27);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(325, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(115, 28);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Ενημέρωση";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(5, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(29, 28);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "-";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // CategoryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtName);
            Name = "CategoryControl";
            Size = new Size(446, 35);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
