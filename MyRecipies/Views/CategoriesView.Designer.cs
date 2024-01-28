namespace MyRecipies.Views
{
    partial class CategoriesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriesView));
            tblCategories = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            txtNewCategory = new TextBox();
            button1 = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // tblCategories
            // 
            tblCategories.AutoScroll = true;
            tblCategories.AutoScrollMinSize = new Size(0, 500);
            tblCategories.ColumnCount = 1;
            tblCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCategories.Location = new Point(22, 49);
            tblCategories.Name = "tblCategories";
            tblCategories.RowCount = 1;
            tblCategories.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblCategories.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblCategories.Size = new Size(450, 500);
            tblCategories.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(33, 11);
            label1.Name = "label1";
            label1.Size = new Size(104, 23);
            label1.TabIndex = 1;
            label1.Text = "Κατηγορίες";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(526, 36);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 2;
            label2.Text = "Νέα Κατηγορία:";
            // 
            // txtNewCategory
            // 
            txtNewCategory.Location = new Point(526, 59);
            txtNewCategory.Name = "txtNewCategory";
            txtNewCategory.Size = new Size(198, 27);
            txtNewCategory.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(730, 59);
            button1.Name = "button1";
            button1.Size = new Size(33, 27);
            button1.TabIndex = 4;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(530, 125);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(190, 32);
            btnClose.TabIndex = 5;
            btnClose.Text = "Κλείσιμο";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // CategoriesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(800, 494);
            Controls.Add(btnClose);
            Controls.Add(button1);
            Controls.Add(txtNewCategory);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tblCategories);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CategoriesView";
            Text = "CategoriesView";
            FormClosed += CategoriesView_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tblCategories;
        private Label label1;
        private Label label2;
        private TextBox txtNewCategory;
        private Button button1;
        private Button btnClose;
    }
}