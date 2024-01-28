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
    public partial class HomeView : Form
    {
        private IAppServices appServices;
        private List<RecipeReadOnlyDTO> recipes = new();
        private List<CategoryDTO> categories = new();
        private List<IngredientSearchControl> ingredientSearchControls = new();
        private List<RecipeShowControl> recipeShowControls = new();
        private RecipeView _recipeView;
        private CategoriesView _categoriesView;
        private IngredientReplaceView _ingredientReplaceView;


        internal HomeView(IAppServices services)
        {
            appServices = services;
            InitializeComponent();

            //populating the cmbCategory
            try
            {
                categories = appServices.CategoriesService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cmbCategory.DataSource = categories;
            cmbCategory.ValueMember = "CategoryName";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = -1;

            //populating the tblIngredientSearch
            IngredientSearchControl control = new IngredientSearchControl()
            {
                Services = appServices
            };
            control.OnAddRowEvent += AddIngrSearchControl;
            control.OnRemoveRowEvent += RemoveSearchControl;
            control.RowIndex = 0;
            ingredientSearchControls.Add(control);
            tblIngredientSearch.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            tblIngredientSearch.Controls.Add(control, 0, 0);



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddIngrSearchControl(IngredientSearchControl control)
        {
            //defining the index from which to apply the changes
            int newIndex = control.RowIndex + 1;
            //adding a new row to the table
            tblIngredientSearch.RowCount++;
            tblIngredientSearch.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            //shifting the controls from newIndex onwards one row  below
            if (newIndex < tblIngredientSearch.RowCount - 1)
            {
                for (int i = tblIngredientSearch.RowCount - 2; i >= newIndex; i--)
                {
                    var item = (IngredientSearchControl?)tblIngredientSearch.GetControlFromPosition(0, i);
                    if (item is not null)
                    {
                        item.RowIndex++;
                        tblIngredientSearch.SetRow(item, i + 1);
                    }
                }
            }
            //adding the new control at newIndex
            IngredientSearchControl newItem = new() { Services = appServices };
            newItem.RowIndex = newIndex;
            newItem.OnAddRowEvent += AddIngrSearchControl;
            newItem.OnRemoveRowEvent += RemoveSearchControl;
            ingredientSearchControls.Add(newItem);
            tblIngredientSearch.Controls.Add(newItem, 0, newIndex);

            //moving the recipiesTable one row below
            tblRecipes.Top += 35;


        }

        private void RemoveSearchControl(IngredientSearchControl control)
        {

            //defining the position from which the changes will be applied
            int index = control.RowIndex;
            //removing the control from the table and the collection
            tblIngredientSearch.Controls.Remove(control);
            //tblIngredientSearch.RowStyles.RemoveAt(index);
            ingredientSearchControls.Remove(control);

            if (ingredientSearchControls.Count == 0)
            {
                IngredientSearchControl newControl = new IngredientSearchControl()
                {
                    Services = appServices
                };
                newControl.OnAddRowEvent += AddIngrSearchControl;
                newControl.OnRemoveRowEvent += RemoveSearchControl;
                newControl.RowIndex = 0;
                ingredientSearchControls.Add(newControl);

                tblIngredientSearch.Controls.Add(newControl, 0, 0);

                return;
            }

            //shifting the following controls one row upwards
            if (index < tblIngredientSearch.RowCount - 1)
            {
                for (int i = index + 1; i < tblIngredientSearch.RowCount; i++)
                {
                    var item = (IngredientSearchControl?)tblIngredientSearch.GetControlFromPosition(0, i);
                    if (item is not null)
                    {
                        item.RowIndex--;
                        tblIngredientSearch.SetRow(item, i - 1);
                    }

                }
            }
            //removing one row from the tblIngredientSearch and shifting the tblRecipes one row upwards
            tblIngredientSearch.RowStyles.RemoveAt(tblIngredientSearch.RowCount - 1);
            tblIngredientSearch.RowCount--;
            //tblIngredientSearch.RowCount--;
            tblRecipes.Top -= 35;


        }

        private void ShowRecipe(int recipeId)
        {
            _recipeView = new(this, appServices, recipeId);
            _recipeView.Show();

        }
        private void SearchRecipes()
        {
            tblRecipes.Controls.Clear();
            tblRecipes.RowStyles.Clear();
            recipeShowControls.Clear();
            tblRecipes.RowCount = 1;

            RecipeSearchDTO criteria = new();

            if (txtName.Text != null && txtName.Text.Length > 0)
            {
                criteria.Name = txtName.Text;
            }

            criteria.Favourite = chckFavorite.Checked;

            if (cmbCategory.SelectedItem != null)
            {
                CategoryDTO categoryDTO = (CategoryDTO)cmbCategory.SelectedItem;
                criteria.Category = categoryDTO.Id;
            }

            if (txtPosition.Text != null && txtPosition.Text.Length > 0)
            {
                criteria.Position = txtPosition.Text;
            }

            foreach (var control in ingredientSearchControls)
            {
                int index = control.GetIngredientIndex();
                if (index >= 0)
                {
                    criteria.Ingerdients.Add(index);
                    Console.WriteLine(index);
                }
            }
            try
            {
                recipes = appServices.RecipiesService.FindRecipes(criteria);

                tblRecipes.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                tblRecipes.Controls.Add(new RecipeHeader(), 0, 0);
                if (recipes.Count > 200)
                {
                    MessageBox.Show("Η αναζήτηση επέστρεψε πάρα πολλά αποτελέσματα. Εμφανίζονται μόνο τα πρώτα 200"
                        , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    recipes.RemoveRange(199, recipes.Count - 200);
                }
                if (recipes.Count > 0)
                {
                    int i = 0;
                    foreach (var recipe in recipes)
                    {
                        i++;
                        tblRecipes.RowCount++;
                        var recipeControl = new RecipeShowControl();
                        recipeControl.LoadRecipe(recipe);
                        recipeControl.OnShowRecipeEvent += ShowRecipe;
                        recipeControl.Index = i;
                        tblRecipes.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                        tblRecipes.Controls.Add(recipeControl, 0, i);
                        recipeShowControls.Add(recipeControl);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRecipes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _recipeView = new(this, appServices);
            _recipeView.Show();

        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            _categoriesView = new CategoriesView(appServices, this);
            _categoriesView.Show();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> deleteList = new();
            int counter = 0;
            foreach (var item in recipeShowControls)
            {
                if (item.IsSelected && item.Recipe is not null)
                {
                    deleteList.Add(item.Recipe.Id);
                    counter++;
                }

            }
            if (counter == 0) return;
            if (MessageBox.Show($"Επιλέχθηκαν {counter} συνταγές. Είστε σίγουρος ότι θέλετε να διαγραφούν;"
                , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                try
                {
                    appServices.RecipiesService.DeleteRecipes(deleteList);
                    SearchRecipes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btIngredients_Click(object sender, EventArgs e)
        {
            _ingredientReplaceView = new IngredientReplaceView(appServices, this);
            _ingredientReplaceView.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tblIngredientSearch.Controls.Clear();
            tblIngredientSearch.RowStyles.Clear();
            ingredientSearchControls.Clear();
            tblIngredientSearch.RowCount = 1;
            tblRecipes.Top = tblIngredientSearch.Bottom + 5;
            IngredientSearchControl control = new IngredientSearchControl()
            {
                Services = appServices
            };
            control.OnAddRowEvent += AddIngrSearchControl;
            control.OnRemoveRowEvent += RemoveSearchControl;
            control.RowIndex = 0;
            ingredientSearchControls.Add(control);
            tblIngredientSearch.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            tblIngredientSearch.Controls.Add(control, 0, 0);

            txtName.Text = "";
            txtPosition.Text = "";
            cmbCategory.SelectedIndex = -1;
            chckFavorite.Checked = false;


        }
    }
}
