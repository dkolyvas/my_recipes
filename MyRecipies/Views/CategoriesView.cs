using MyRecipies.Controls;
using MyRecipies.DTO;
using MyRecipies.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRecipies.Views
{
    public partial class CategoriesView : Form
    {
        private IAppServices _service;
        private List<CategoryDTO> _categories;
        private HomeView _homeView;

        internal CategoriesView(IAppServices services, HomeView homeView)
        {
            InitializeComponent();
            _service = services;
            _homeView = homeView;
            _homeView.Enabled = false;
            LoadCategories();

        }

        private void LoadCategories()
        {
            try
            {
                _categories = _service.CategoriesService.GetAll();
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewCategory.Text.Length == 0) return;
            try
            {
                var newCategory = _service.CategoriesService.Add(txtNewCategory.Text);
                _categories.Add(newCategory);
                int index = ++tblCategories.RowCount;
                tblCategories.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
                CategoryControl item = new(_service);
                item.LoadCategory(newCategory);
                item.OnDeleteEvent += DeleteCategory;
                tblCategories.Controls.Clear();
                LoadTable();
                txtNewCategory.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCategory(CategoryControl item)
        {
            if (item.Category is null) return;
            int id = item.Category.Id;
            try
            {
                _service.CategoriesService.DeleteById(id);
                var category = _categories.FirstOrDefault(c => c.Id == id);
                if (category is not null) _categories.Remove(category);
                tblCategories.Controls.Clear();
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadTable()
        {
            int i = 0;
            tblCategories.RowStyles.Clear();
            foreach (CategoryDTO category in _categories)
            {
                i++;
                tblCategories.RowCount = i;
                tblCategories.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
                CategoryControl item = new(_service);
                item.OnDeleteEvent += DeleteCategory;
                item.LoadCategory(category);
                tblCategories.Controls.Add(item, 0, i);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CategoriesView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _homeView.Enabled = true;
        }
    }
}
