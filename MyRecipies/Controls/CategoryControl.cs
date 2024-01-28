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

namespace MyRecipies.Controls
{
    public partial class CategoryControl : UserControl
    {
        private IAppServices _service;
        internal CategoryDTO? Category { get; set; }
        internal delegate void DeleteCategory(CategoryControl item);
        internal DeleteCategory OnDeleteEvent;
        internal CategoryControl(IAppServices service)
        {
            InitializeComponent();
            _service = service;
        }

        internal void LoadCategory(CategoryDTO category)
        {
            Category = category;
            txtName.Text = category.CategoryName;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Category == null) return;

            Category.CategoryName = txtName.Text;
            try
            {
                var result = _service.CategoriesService.Update(Category);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteEvent.Invoke(this);
        }
    }
}
