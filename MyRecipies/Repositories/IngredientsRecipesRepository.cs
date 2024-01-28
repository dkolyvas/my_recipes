using Microsoft.EntityFrameworkCore;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Repositories
{
    internal class IngredientsRecipesRepository
    {
        private MyrecipesContext _context;

        public IngredientsRecipesRepository(MyrecipesContext context)
        {
            _context = context;
        }

        public List<IngredientsRecipe> GetRecipeIngredients(int recipeId)
        {
            return _context.IngredientsRecipes.Where(ir => ir.RecipeId == recipeId).Include(ir => ir.Ingredient).ToList();

        }

        public List<IngredientsRecipe> AddRange(List<IngredientsRecipe> ingredients)
        {
           

            _context.IngredientsRecipes.AddRange(ingredients);
            return ingredients;
        }

        public IngredientsRecipe Add(IngredientsRecipe ingredient)
        {
      
            _context.IngredientsRecipes.Add(ingredient);
            return ingredient;
        }

        public bool Delete(int id)
        {
            var ingredient = _context.IngredientsRecipes.Find(id);
            if (ingredient == null) return false;
            _context.IngredientsRecipes.Remove(ingredient);
            return true;
            
        }

        public IngredientsRecipe? Update(IngredientsRecipe ingredient)
        {
            var updated = _context.IngredientsRecipes.Find(ingredient.Id);
            if (updated is not null)
            {
                _context.Entry(updated).CurrentValues.SetValues(ingredient);
                _context.Entry(updated).State = EntityState.Modified;
            }
            return updated;
        }
    }
}
