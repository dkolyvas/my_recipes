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
    public partial class IngredientReplaceView : Form
    {
        private IAppServices _service;
        private HomeView _parentForm;
        internal IngredientReplaceView(IAppServices service, HomeView parentForm)
        {
            _service = service;
            _parentForm = parentForm;
            InitializeComponent();
            ctrOldIngredient.Services = _service;
            ctrOldIngredient.SetReplaceMode();
            ctrNewIngredient.Services = service;
            ctrNewIngredient.SetReplaceMode();
            _parentForm.Enabled = false;
        }

        private void txtApply_Click(object sender, EventArgs e)
        {
            if (ctrOldIngredient.SelectedIngredient is null || ctrNewIngredient.SelectedIngredient is null) return;

            int oldIngr = ctrOldIngredient.SelectedIngredient.Id;
            int newIngr = ctrNewIngredient.SelectedIngredient.Id;
            try
            {
                int result = _service.IngredientsService.ReplaceIngredient(oldIngr, newIngr);
                MessageBox.Show($"Έγινε αντικατάσταση συστατικού σε {result} συνταγές", "Notification",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrOldIngredient.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IngedientReplaceView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parentForm.Enabled = true;
        }
    }
}
