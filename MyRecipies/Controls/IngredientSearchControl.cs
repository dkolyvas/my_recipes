using MyRecipies.DTO;
using MyRecipies.Services;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MyRecipies.Controls
{
    public partial class IngredientSearchControl : UserControl
    {
        internal IAppServices? Services { get; set; }
        private List<IngredientDTO> ingredientList;
        internal IngredientDTO? SelectedIngredient { get; set; }
        public delegate void AddRow(IngredientSearchControl searchContol);
        public AddRow OnAddRowEvent;
        public delegate void RemoveRow(IngredientSearchControl searchControl);
        public RemoveRow OnRemoveRowEvent;
        public int RowIndex { get; set; } = -1;

        public IngredientSearchControl()
        {
            
            InitializeComponent();
            cmbIngrSelect.DataSource = ingredientList;
            cmbIngrSelect.DisplayMember = "IngredientName";
            cmbIngrSelect.ValueMember = "Id";
            cmbIngrSelect.SelectedIndex = -1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemoveRowEvent?.Invoke(this);

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddRowEvent?.Invoke(this);
        }

        private void cmbIngrSelect_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchCriteria = cmbIngrSelect.Text;
                ingredientList = Services.IngredientsService.GetByName(searchCriteria);
                cmbIngrSelect.DataSource= ingredientList;
                cmbIngrSelect.Select(searchCriteria.Length, cmbIngrSelect.Text.Length - searchCriteria.Length);

                if (ingredientList.Count == 1) SelectedIngredient = ingredientList[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbIngrSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectedIngredient = (IngredientDTO)cmbIngrSelect.SelectedItem;

        }

        public int GetIngredientIndex()
        {
           if(cmbIngrSelect.SelectedIndex >=0) return (int)cmbIngrSelect.SelectedValue;
           else return -1;
        }

        public void Reset()
        {
            //ingredientList.Clear();
            //cmbIngrSelect.DataSource = null;
            cmbIngrSelect.Text = string.Empty;
           // SelectedIngredient = null;
           // cmbIngrSelect.Text = string.Empty;
        }

        public void SetReplaceMode()
        {
            btnAdd.Visible = false;
            btnRemove.Visible = false;
        }
    }
}
