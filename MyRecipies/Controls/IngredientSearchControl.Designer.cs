namespace MyRecipies.Controls
{
    partial class IngredientSearchControl
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
            btnRemove = new Button();
            cmbIngrSelect = new ComboBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(12, 2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(33, 29);
            btnRemove.TabIndex = 0;
            btnRemove.Text = "-";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // cmbIngrSelect
            // 
            cmbIngrSelect.FormattingEnabled = true;
            cmbIngrSelect.Location = new Point(42, 3);
            cmbIngrSelect.Name = "cmbIngrSelect";
            cmbIngrSelect.Size = new Size(280, 28);
            cmbIngrSelect.TabIndex = 1;
            cmbIngrSelect.SelectionChangeCommitted += cmbIngrSelect_SelectionChangeCommitted;
            cmbIngrSelect.TextChanged += cmbIngrSelect_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(317, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(30, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // IngredientSearchContol
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAdd);
            Controls.Add(cmbIngrSelect);
            Controls.Add(btnRemove);
            Name = "IngredientSearchContol";
            Size = new Size(358, 34);
            ResumeLayout(false);
        }

        #endregion

        private Button btnRemove;
        private ComboBox cmbIngrSelect;
       
        private Button btnAdd;
    }
}
