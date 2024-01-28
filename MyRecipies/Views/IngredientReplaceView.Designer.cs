namespace MyRecipies.Views
{
    partial class IngredientReplaceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngredientReplaceView));
            ctrOldIngredient = new Controls.IngredientSearchControl();
            ctrNewIngredient = new Controls.IngredientSearchControl();
            label1 = new Label();
            label2 = new Label();
            btnApply = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // ctrOldIngredient
            // 
            ctrOldIngredient.Location = new Point(25, 52);
            ctrOldIngredient.Name = "ctrOldIngredient";
            ctrOldIngredient.RowIndex = -1;
            ctrOldIngredient.Size = new Size(351, 31);
            ctrOldIngredient.TabIndex = 0;
            // 
            // ctrNewIngredient
            // 
            ctrNewIngredient.Location = new Point(393, 52);
            ctrNewIngredient.Name = "ctrNewIngredient";
            ctrNewIngredient.RowIndex = -1;
            ctrNewIngredient.Size = new Size(351, 31);
            ctrNewIngredient.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 23);
            label1.Name = "label1";
            label1.Size = new Size(189, 20);
            label1.TabIndex = 2;
            label1.Text = "Αντικατάσαση συστατικού";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 23);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 3;
            label2.Text = "με Συστατικό";
            // 
            // btnApply
            // 
            btnApply.Location = new Point(97, 113);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(146, 31);
            btnApply.TabIndex = 4;
            btnApply.Text = "Αντικατάσταση";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += txtApply_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(496, 115);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(131, 29);
            btnClose.TabIndex = 5;
            btnClose.Text = "Κλείσιμο";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += button1_Click;
            // 
            // IngredientReplaceView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 206);
            Controls.Add(btnClose);
            Controls.Add(btnApply);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctrNewIngredient);
            Controls.Add(ctrOldIngredient);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "IngredientReplaceView";
            Text = "IngedientReplaceView";
            FormClosing += IngedientReplaceView_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.IngredientSearchControl ctrOldIngredient;
        private Controls.IngredientSearchControl ctrNewIngredient;
        private Label label1;
        private Label label2;
        private Button btnApply;
        private Button btnClose;
    }
}