namespace MyRecipies.Controls
{
    partial class RecipeIngredientControl
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
            cmbIngredient = new ComboBox();
            txtQuantity = new TextBox();
            txtComments = new TextBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(8, 1);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(26, 30);
            btnRemove.TabIndex = 0;
            btnRemove.Text = "-";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // cmbIngredient
            // 
            cmbIngredient.FormattingEnabled = true;
            cmbIngredient.Location = new Point(40, 1);
            cmbIngredient.Name = "cmbIngredient";
            cmbIngredient.Size = new Size(222, 28);
            cmbIngredient.TabIndex = 1;
            cmbIngredient.SelectionChangeCommitted += cmbIngredient_SelectionChangeCommitted;
            cmbIngredient.TextChanged += cmbIngredient_TextChanged;
            cmbIngredient.Leave += cmbIngredient_Leave;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(268, 1);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(131, 27);
            txtQuantity.TabIndex = 2;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // txtComments
            // 
            txtComments.Location = new Point(405, 1);
            txtComments.Name = "txtComments";
            txtComments.Size = new Size(267, 27);
            txtComments.TabIndex = 3;
            txtComments.TextChanged += txtComments_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(678, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(33, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // RecipeIngredientControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAdd);
            Controls.Add(txtComments);
            Controls.Add(txtQuantity);
            Controls.Add(cmbIngredient);
            Controls.Add(btnRemove);
            Name = "RecipeIngredientControl";
            Size = new Size(724, 31);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRemove;
        private ComboBox cmbIngredient;
        private TextBox txtQuantity;
        private TextBox txtComments;
        private Button btnAdd;
    }
}
