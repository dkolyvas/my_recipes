using MyRecipies.Controls;
using recipes.Data;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyRecipies.Utilities;

namespace MyRecipies.Views
{
    public partial class RecipeView : Form
    {
        private IAppServices _service;
        private HomeView _parentView;
        private int _recipeId;
        private RecipeReadOnlyDTO? _recipe;
        private List<int> deleteList = new();
        private List<IngredientsRecReadOnlyDTO> _ingredients = new();
        private List<RecipeIngredientControl> _ingredientControls = new();
        private bool isCommited = true;
        internal RecipeView(HomeView parentView, IAppServices service, int recipeId = -1)
        {
            InitializeComponent();
            _parentView = parentView;
            _service = service;
            _recipeId = recipeId;

            if (_recipeId == -1)
            {
                SetNewRecipe();
            }
            else
            {
                LoadRecipe();
            }
            _parentView.Enabled = false;
            isCommited = true;

        }

        private void LoadRecipe()
        {
            try
            {
                _recipe = _service.RecipiesService.FindRecipe(_recipeId);
                _ingredients = _service.RecipiesService.FindIngredients(_recipeId);
                List<CategoryDTO> categories = _service.CategoriesService.GetAll();

                txtName.Text = _recipe.RecipeName;

                cmbCategory.DataSource = categories;
                cmbCategory.ValueMember = "Id";
                cmbCategory.DisplayMember = "CategoryName";
                var index = categories.FindIndex(c => c.Id == _recipe.CategoryId);
                cmbCategory.SelectedIndex = index;

                txtPosition.Text = _recipe.Position;
                txtImplementation.Text = _recipe.Implementation;

                chckFavorite.Checked = _recipe.Favourite;

                chckImplemented.Checked = _recipe.Made;

                tblIngredients.RowStyles.Clear();
                tblIngredients.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
                tblIngredients.Controls.Add(new IngredientHeaderControl(), 0, 0);
                int i = 0;

                if (_ingredients.Count > 0)
                {

                    foreach (var ingredient in _ingredients)
                    {
                        i++;
                        /*RecipeIngredientControl control = new() { Services = _service, RowIndex = i };*/
                        var control = SetupNewIngredientControl(i);
                        control.LoadIngredient(ingredient);
                        /*   control.OnAddIngredietnEvent += AddIngredient;
                           control.OnRemoveIngredientEvent += RemoveIngredient;
                           _ingredientControls.Add(control);*/
                        tblIngredients.RowCount++;
                        tblIngredients.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
                        tblIngredients.Controls.Add(control, 0, i);
                    }

                }
                i++;
                var newControl = SetupNewIngredientControl(i);
                tblIngredients.RowCount++;
                tblIngredients.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
                tblIngredients.Controls.Add(newControl, 0, i);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetNewRecipe()
        {
            try
            {
                List<CategoryDTO> categories = _service.CategoriesService.GetAll();

                cmbCategory.DataSource = categories;
                cmbCategory.ValueMember = "Id";
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.SelectedIndex = -1;

                tblIngredients.RowStyles.Clear();
                tblIngredients.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
                tblIngredients.Controls.Add(new IngredientHeaderControl(), 0, 0);

                var newControl = SetupNewIngredientControl(1);
                tblIngredients.RowCount++;
                tblIngredients.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
                tblIngredients.Controls.Add(newControl, 0, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddIngredient(RecipeIngredientControl control)
        {
            int newIndex = control.RowIndex + 1;

            tblIngredients.RowCount++;
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));

            if (newIndex < tblIngredients.RowCount - 1)
            {
                for (int i = tblIngredients.RowCount - 2; i >= newIndex; i--)
                {
                    var item = (RecipeIngredientControl?)tblIngredients.GetControlFromPosition(0, i);
                    if (item is not null)
                    {
                        item.RowIndex++;
                        tblIngredients.SetRow(item, i + 1);
                    }
                }
            }
            RecipeIngredientControl newControl = SetupNewIngredientControl(newIndex);
            newControl.RecipeId = _recipeId;
            // _ingredientControls.Add(newControl);
            tblIngredients.Controls.Add(newControl, 0, newIndex);

        }

        private void RemoveIngredient(RecipeIngredientControl control)
        {
            int index = control.RowIndex;
            tblIngredients.Controls.Remove(control);
            if (control.Ingredient is not null) deleteList.Add(control.Ingredient.Id);
            _ingredientControls.Remove(control);
            if (_ingredientControls.Count == 0)
            {
                var newControl = SetupNewIngredientControl(index);
                tblIngredients.Controls.Add(newControl, 0, 1);

                return;
            }

            if (index < tblIngredients.RowCount - 1)
            {
                for (int i = index + 1; i < tblIngredients.RowCount; i++)
                {
                    var item = (RecipeIngredientControl?)tblIngredients.GetControlFromPosition(0, i);
                    if (item is not null)
                    {
                        item.RowIndex--;
                        tblIngredients.SetRow(item, i - 1);
                    }
                }
            }

            tblIngredients.RowStyles.RemoveAt(tblIngredients.RowCount - 1);
            tblIngredients.RowCount--;



        }

        private RecipeIngredientControl SetupNewIngredientControl(int index)
        {
            RecipeIngredientControl control = new() { Services = _service, RowIndex = index };
            control.OnAddIngredietnEvent += AddIngredient;
            control.OnRemoveIngredientEvent += RemoveIngredient;
            control.OnUpdated += NotifyChanges;
            _ingredientControls.Add(control);
            return control;

        }

        private void RecipeView_Shown(object sender, EventArgs e)
        {
            _parentView.Enabled = false;
        }

        private bool AddRecipe()
        {
            RecipeInsertDTO recipe = new();
            List<IngredientsRecInsertDTO> recIngredients = new();
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Πρέπει να ορίσετε ένα όνομα συνταγής", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Πρέπει να ορίσετε μία κατηγορία", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            recipe.RecipeName = txtName.Text;
            recipe.Favourite = chckFavorite.Checked;
            recipe.Made = chckImplemented.Checked;

            recipe.CategoryId = (int)cmbCategory.SelectedValue;

            if (txtPosition.Text.Length > 0)
            {
                recipe.Position = txtPosition.Text;
            }
            if (txtImplementation.Text.Length > 0)
            {
                recipe.Implementation = txtImplementation.Text;
            }

            foreach (var ingredientControl in _ingredientControls)
            {
                if (ingredientControl.IsUpdated)
                {
                    recIngredients.Add(ingredientControl.GetNewRecIngredient());
                }

            }
            recIngredients.Sort((a, b) => a.Index - b.Index);

            try
            {
                var addedRecipe = _service.RecipiesService.AddRecipe(recipe, recIngredients);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private bool UpdateRecipe()
        {
            RecipeUpdateDTO updatedRecipe = new();
            if (_recipeId < 0) return false;
            updatedRecipe.Id = _recipeId;

            List<IngredientsRecUpdateDTO> updateList = new();
            List<IngredientsRecInsertDTO> insertList = new();

            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Πρέπει να ορίσετε ένα όνομα συνταγής", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Πρέπει να ορίσετε μία κατηγορία", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            updatedRecipe.RecipeName = txtName.Text;
            updatedRecipe.Favourite = chckFavorite.Checked;
            updatedRecipe.Made = chckImplemented.Checked;
            updatedRecipe.CategoryId = (int)cmbCategory.SelectedValue;

            if (txtPosition.Text.Length > 0)
            {
                updatedRecipe.Position = txtPosition.Text;
            }
            if (txtImplementation.Text.Length > 0)
            {
                updatedRecipe.Implementation = txtImplementation.Text;
            }

            foreach (var control in _ingredientControls)
            {
                if (control.IsUpdated)
                {
                    if (control.IsNew)
                    {
                        insertList.Add(control.GetNewRecIngredient());
                    }
                    else
                    {
                        updateList.Add(control.GetUpdatedIngredient());
                    }
                }
            }
            insertList.Sort((a, b) => a.Index - b.Index);

            try
            {
                var result = _service.RecipiesService.UpdateRecipe(updatedRecipe, insertList, updateList, deleteList);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

        }
        private bool SaveChanges()
        {
            bool result = false;
            if (_recipeId > 0)
            {
                result = UpdateRecipe();
            }
            else
            {
                result = AddRecipe();
            }
            isCommited = true;
            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool result = SaveChanges();
            _parentView.Enabled = true;
            if (result) this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCommited = true;
            this.Close();
            _parentView.Enabled = true;
        }

        private void RecipeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isCommited)
            {
                if (MessageBox.Show("Θέλετε να αποθηκεύεσετε τις αλλαγές;", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if (!SaveChanges())
                    {
                        e.Cancel = true;
                        return;
                    }
                }

            }
            _parentView.Enabled = true;

        }

        private void NotifyChanges()
        {
            isCommited = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            NotifyChanges();
        }

        private void chckFavorite_CheckedChanged(object sender, EventArgs e)
        {
            NotifyChanges();
        }

        private void chckImplemented_CheckedChanged(object sender, EventArgs e)
        {
            NotifyChanges();
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            NotifyChanges();
        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {
            NotifyChanges();
        }

        private void txtImplementation_TextChanged(object sender, EventArgs e)
        {
            NotifyChanges();
        }

        private void mnImplementation_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mnImplementation_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mniCopy":
                    if (txtImplementation.SelectionLength > 0) txtImplementation.Copy();
                    mnImplementation.Hide();
                    break;
                case "mniCut":
                    if (txtImplementation.SelectionLength > 0) txtImplementation.Cut();
                    mnImplementation.Hide();
                    break;
                case "mniPaste":
                    txtImplementation.Paste();
                    mnImplementation.Hide();
                    break;
                default:
                    mnImplementation.Hide();
                    break;


            }
        }

        private void txtImplementation_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnImplementation.Top = e.Y;
                mnImplementation.Left = e.X;
                mnImplementation.Show();
            }
        }

        private void RecipeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mnImplementation.Hide();
            }
        }

        private void RecipeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                mnImplementation.Hide();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(_recipe is not  null)
            {
                try
                {
                    PdfExtractUtil.CreateDocument(_recipe, _ingredients);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
