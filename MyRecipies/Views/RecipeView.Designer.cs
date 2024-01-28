namespace MyRecipies.Views
{
    partial class RecipeView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeView));
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            cmbCategory = new ComboBox();
            label3 = new Label();
            txtPosition = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            tblIngredients = new TableLayoutPanel();
            txtImplementation = new TextBox();
            label4 = new Label();
            chckFavorite = new CheckBox();
            chckImplemented = new CheckBox();
            mnImplementation = new ContextMenuStrip(components);
            mniCopy = new ToolStripMenuItem();
            mniCut = new ToolStripMenuItem();
            mniPaste = new ToolStripMenuItem();
            btnPrint = new Button();
            mnImplementation.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 15);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 0;
            label1.Text = "Όνομα Συνταγής";
            // 
            // txtName
            // 
            txtName.Location = new Point(170, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(323, 27);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 59);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 2;
            label2.Text = "Κατηγορία";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(170, 51);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 28);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedValueChanged += cmbCategory_SelectedValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(437, 59);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 4;
            label3.Text = "Θέση";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(504, 52);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(165, 27);
            txtPosition.TabIndex = 5;
            txtPosition.TextChanged += txtPosition_TextChanged;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(853, 32);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(136, 29);
            btnOk.TabIndex = 6;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1034, 32);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Ακύρωση";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tblIngredients
            // 
            tblIngredients.AutoSize = true;
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblIngredients.Location = new Point(36, 99);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 1;
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblIngredients.Size = new Size(730, 37);
            tblIngredients.TabIndex = 8;
            // 
            // txtImplementation
            // 
            txtImplementation.Location = new Point(785, 128);
            txtImplementation.Multiline = true;
            txtImplementation.Name = "txtImplementation";
            txtImplementation.ScrollBars = ScrollBars.Vertical;
            txtImplementation.Size = new Size(395, 370);
            txtImplementation.TabIndex = 9;
            txtImplementation.TextChanged += txtImplementation_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(799, 100);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 10;
            label4.Text = "Εκτέλεση";
            // 
            // chckFavorite
            // 
            chckFavorite.AutoSize = true;
            chckFavorite.Location = new Point(533, 14);
            chckFavorite.Name = "chckFavorite";
            chckFavorite.Size = new Size(109, 24);
            chckFavorite.TabIndex = 11;
            chckFavorite.Text = "Αγαπημένη";
            chckFavorite.UseVisualStyleBackColor = true;
            chckFavorite.CheckedChanged += chckFavorite_CheckedChanged;
            // 
            // chckImplemented
            // 
            chckImplemented.AutoSize = true;
            chckImplemented.Location = new Point(662, 14);
            chckImplemented.Name = "chckImplemented";
            chckImplemented.Size = new Size(166, 24);
            chckImplemented.TabIndex = 12;
            chckImplemented.Text = "Πραγματοποιήθηκε";
            chckImplemented.UseVisualStyleBackColor = true;
            chckImplemented.CheckedChanged += chckImplemented_CheckedChanged;
            // 
            // mnImplementation
            // 
            mnImplementation.ImageScalingSize = new Size(20, 20);
            mnImplementation.Items.AddRange(new ToolStripItem[] { mniCopy, mniCut, mniPaste });
            mnImplementation.Name = "mnImplementation";
            mnImplementation.Size = new Size(153, 76);
            mnImplementation.Opening += mnImplementation_Opening;
            mnImplementation.ItemClicked += mnImplementation_ItemClicked;
            // 
            // mniCopy
            // 
            mniCopy.Name = "mniCopy";
            mniCopy.Size = new Size(152, 24);
            mniCopy.Text = "Αντιγραφή";
            // 
            // mniCut
            // 
            mniCut.Name = "mniCut";
            mniCut.Size = new Size(152, 24);
            mniCut.Text = "Αποκοπή";
            // 
            // mniPaste
            // 
            mniPaste.Name = "mniPaste";
            mniPaste.Size = new Size(152, 24);
            mniPaste.Text = "Επικόληση";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(935, 79);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(127, 31);
            btnPrint.TabIndex = 13;
            btnPrint.Text = "Εκτύπωση";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // RecipeView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1222, 697);
            Controls.Add(btnPrint);
            Controls.Add(chckImplemented);
            Controls.Add(chckFavorite);
            Controls.Add(label4);
            Controls.Add(txtImplementation);
            Controls.Add(tblIngredients);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtPosition);
            Controls.Add(label3);
            Controls.Add(cmbCategory);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RecipeView";
            Text = "RecipeView";
            FormClosing += RecipeView_FormClosing;
            Shown += RecipeView_Shown;
            mnImplementation.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private ComboBox cmbCategory;
        private Label label3;
        private TextBox txtPosition;
        private Button btnOk;
        private Button btnCancel;
        private TableLayoutPanel tblIngredients;
        private TextBox txtImplementation;
        private Label label4;
        private CheckBox chckFavorite;
        private CheckBox chckImplemented;
        private ContextMenuStrip mnImplementation;
        private ToolStripMenuItem mniCopy;
        private ToolStripMenuItem mniCut;
        private ToolStripMenuItem mniPaste;
        private Button btnPrint;
    }
}