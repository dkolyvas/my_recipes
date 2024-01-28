using MyRecipies.DTO;
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
    public partial class RecipeShowControl : UserControl
    {
        internal RecipeReadOnlyDTO? Recipe { get; set; }
        public int Index { get; set; }
        public delegate void ShowRecipe(int recipeId);
        public bool IsSelected { get; set; }
        public ShowRecipe OnShowRecipeEvent;

        public RecipeShowControl()
        {
            InitializeComponent();
        }
        internal void LoadRecipe(RecipeReadOnlyDTO recipe)
        {
            Recipe = recipe;
            txtName.Text = recipe.RecipeName;
            txtCategory.Text = recipe.CategoryName;
            txtPosition.Text = recipe.Position;
            chckFavorite.Checked = recipe.Favourite;
            chckImplemented.Checked = recipe.Made;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Recipe is not null) 
            {
                OnShowRecipeEvent.Invoke(Recipe.Id);
            }

        }

        private void chckSelect_CheckedChanged(object sender, EventArgs e)
        {
            IsSelected = chckSelect.Checked;

        }
    }
}
