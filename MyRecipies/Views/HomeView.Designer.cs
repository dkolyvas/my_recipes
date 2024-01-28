namespace MyRecipies.Views
{
    partial class HomeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtPosition = new TextBox();
            label4 = new Label();
            cmbCategory = new ComboBox();
            chckFavorite = new CheckBox();
            label5 = new Label();
            tblIngredientSearch = new TableLayoutPanel();
            btnSearch = new Button();
            tblRecipes = new TableLayoutPanel();
            btnAdd = new Button();
            btnCategories = new Button();
            btIngredients = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(221, 28);
            label1.TabIndex = 0;
            label1.Text = "Αναζήτηση Συνταγών";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 50);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 1;
            label2.Text = "Όνομα";
            // 
            // txtName
            // 
            txtName.Location = new Point(99, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(182, 27);
            txtName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(287, 50);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 3;
            label3.Text = "Θέση";
            label3.Click += label3_Click;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(338, 47);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(116, 27);
            txtPosition.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(475, 50);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 5;
            label4.Text = "Κατηγορία";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(563, 46);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(177, 28);
            cmbCategory.TabIndex = 6;
            // 
            // chckFavorite
            // 
            chckFavorite.AutoSize = true;
            chckFavorite.Location = new Point(764, 50);
            chckFavorite.Name = "chckFavorite";
            chckFavorite.Size = new Size(157, 24);
            chckFavorite.TabIndex = 7;
            chckFavorite.Text = "Μόνο Αγαπημένες";
            chckFavorite.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 94);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 8;
            label5.Text = "Συστατικά";
            // 
            // tblIngredientSearch
            // 
            tblIngredientSearch.AutoSize = true;
            tblIngredientSearch.ColumnCount = 1;
            tblIngredientSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblIngredientSearch.Location = new Point(152, 94);
            tblIngredientSearch.Name = "tblIngredientSearch";
            tblIngredientSearch.RowCount = 1;
            tblIngredientSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblIngredientSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblIngredientSearch.Size = new Size(440, 34);
            tblIngredientSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(598, 94);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(185, 34);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Αναζήτηση";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tblRecipes
            // 
            tblRecipes.AutoSize = true;
            tblRecipes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblRecipes.ColumnCount = 1;
            tblRecipes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRecipes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRecipes.Location = new Point(28, 149);
            tblRecipes.Name = "tblRecipes";
            tblRecipes.RowCount = 1;
            tblRecipes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRecipes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRecipes.Size = new Size(0, 0);
            tblRecipes.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(790, 94);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(185, 34);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "+ Προσθήκη Νέας";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCategories
            // 
            btnCategories.Location = new Point(1032, 12);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(134, 30);
            btnCategories.TabIndex = 13;
            btnCategories.Text = "Κατηγορίες";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btIngredients
            // 
            btIngredients.Location = new Point(1035, 56);
            btIngredients.Name = "btIngredients";
            btIngredients.Size = new Size(134, 30);
            btIngredients.TabIndex = 14;
            btIngredients.Text = "Συστατικά";
            btIngredients.UseVisualStyleBackColor = true;
            btIngredients.Click += btIngredients_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(984, 94);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(185, 34);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Διαγραφή Επιλεγμένων";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(927, 44);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Ανανέωση";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // HomeView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1190, 760);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btIngredients);
            Controls.Add(btnCategories);
            Controls.Add(btnAdd);
            Controls.Add(tblRecipes);
            Controls.Add(btnSearch);
            Controls.Add(tblIngredientSearch);
            Controls.Add(label5);
            Controls.Add(chckFavorite);
            Controls.Add(cmbCategory);
            Controls.Add(label4);
            Controls.Add(txtPosition);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HomeView";
            Text = "HomeView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtPosition;
        private Label label4;
        private ComboBox cmbCategory;
        private CheckBox chckFavorite;
        private Label label5;
        private TableLayoutPanel tblIngredientSearch;
        private Button btnSearch;
        private TableLayoutPanel tblRecipes;
        private Button btnAdd;
        private Button btnCategories;
        private Button btIngredients;
        private Button btnDelete;
        private Button btnRefresh;
    }
}