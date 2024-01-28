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
    public partial class RecipeIngredientControl : UserControl
    {
        internal IngredientsRecReadOnlyDTO? Ingredient { get; set; }
        private List<IngredientDTO> ingredients = new();
        private IngredientDTO selectedIngredient;
        internal delegate void EditIngredient(RecipeIngredientControl control);
        internal delegate void Updated();

        internal EditIngredient OnAddIngredietnEvent;
        internal EditIngredient OnRemoveIngredientEvent;
        internal Updated OnUpdated;
        internal bool IsNew = true;
        internal bool IsUpdated = false;
        internal int RowIndex { get; set; } = 0;
        internal IAppServices? Services { get; set; }
        internal int? RecipeId { get; set; } = -1;

        public RecipeIngredientControl()
        {
            InitializeComponent();
            cmbIngredient.DataSource = ingredients;
            cmbIngredient.ValueMember = "Id";
            cmbIngredient.DisplayMember = "IngredientName";
            cmbIngredient.SelectedIndex = -1;
            IsUpdated = false;

        }

        internal void LoadIngredient(IngredientsRecReadOnlyDTO data)
        {
            RecipeId = data.RecipeId;
            this.Ingredient = data;
            IsNew = false;
            if (data.IngredientId > 0)
            {
                IngredientDTO ingredient = new() { Id = data.IngredientId, IngredientName = data.IngredientName };

                ingredients = new List<IngredientDTO> { ingredient };
                cmbIngredient.DataSource = ingredients;
            }
            
           // cmbIngredient.SelectedIndex = 0;


            txtQuantity.Text = data.Quantity;
            txtComments.Text = data.Comments;
            IsUpdated = false;

        }

        private void cmbIngredient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchCriteria = cmbIngredient.Text;
                ingredients = Services.IngredientsService.GetByName(searchCriteria);
                cmbIngredient.DataSource = ingredients;
                cmbIngredient.Select(searchCriteria.Length, cmbIngredient.Text.Length - searchCriteria.Length);

                if (ingredients.Count == 1) selectedIngredient = ingredients[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemoveIngredientEvent.Invoke(this);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddIngredietnEvent.Invoke(this);
        }

        private void cmbIngredient_SelectionChangeCommitted(object sender, EventArgs e)
        {

            IsUpdated = true;
            OnUpdated.Invoke();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            IsUpdated = true;
            OnUpdated.Invoke();
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            IsUpdated = true;
            OnUpdated.Invoke();
        }

        internal IngredientsRecInsertDTO GetNewRecIngredient()
        {
            IngredientsRecInsertDTO newIngr = new()
            {
                RecipeId = RecipeId,

                IngredientId = cmbIngredient.SelectedValue != null ? (int)cmbIngredient.SelectedValue : null,
                Quantity = txtQuantity.Text,
                Comments = txtComments.Text,
                Index = RowIndex
            };
            return newIngr;
        }

        internal IngredientsRecUpdateDTO GetUpdatedIngredient()
        {
            IngredientsRecUpdateDTO updatedIngr = new()
            {
                RecipeId = Ingredient.RecipeId,
                IngredientId = cmbIngredient.SelectedValue != null ? (int)cmbIngredient.SelectedValue : null,
                Quantity = txtQuantity.Text,
                Comments = txtComments.Text,
                Id = Ingredient.Id
            };
            return updatedIngr;
        }

        private void cmbIngredient_Leave(object sender, EventArgs e)
        {
            string ingredientName = cmbIngredient.Text;
            if(ingredientName.Length > 0  && ingredients.Count ==0) 
            {
                List<IngredientDTO> test = Services.IngredientsService.GetByName(ingredientName);
                if( test.Count == 0)
                {
                    try
                    {
                        IngredientDTO newIngredient = Services.IngredientsService.Add(ingredientName);
                        ingredients = new List<IngredientDTO> { newIngredient };
                        cmbIngredient.DataSource = ingredients;
                        cmbIngredient.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
