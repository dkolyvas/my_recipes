using Microsoft.EntityFrameworkCore;

using MyRecipies.DTO;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Repositories
{
    internal class RecipiesRepository
    {
        private MyrecipesContext _context;

        public RecipiesRepository(MyrecipesContext context)
        {
            _context = context;
        }

        public List<Recipe> GetList(RecipeSearchDTO searchCriteria)
        {
            var query = _context.Recipes.Include(r => r.IngredientsRecipes).AsQueryable();
            if(searchCriteria.Name != null)
            {
                query = query.Where(r => r.RecipeName.Contains(searchCriteria.Name));
            }
            if(searchCriteria.Category != null)
            {
                query = query.Where(r => r.CategoryId == searchCriteria.Category);
            }
            if(searchCriteria.Favourite == true)
            {
                query = query.Where(r => r.Favourite == true);
            }
            if(searchCriteria.Position != null)
            {
                query = query.Where(r => r.Position.StartsWith(searchCriteria.Position));
            }
            if(searchCriteria.Ingerdients.Count > 0)
            {
                foreach(var item in searchCriteria.Ingerdients)
                {
                    query = query.Where(r => r.IngredientsRecipes.Any(i => i.IngredientId == item));
                }
            }
            return query.ToList();
        }

        public Recipe? GetOne(int id)
        {
            return _context.Recipes.Include(r => r.IngredientsRecipes).FirstOrDefault(r => r.Id == id);
        }

        public Recipe? Add(Recipe recipe)
        {
            
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return recipe;
        }

        public bool Delete(int id)
        {
            Recipe? recipe = _context.Recipes.Include(r => r.IngredientsRecipes).FirstOrDefault(r => r.Id == id);
            if (recipe == null) return false;
            if (recipe.IngredientsRecipes.Count > 0)
            {
                _context.RemoveRange(recipe.IngredientsRecipes);
            }
            _context.Remove(recipe);
            return true;
        }

        public Recipe? Update(Recipe recipe)
        {
            var oldValues = _context.Recipes.Find(recipe.Id);
            if (oldValues != null)
            {
                _context.Entry(oldValues).CurrentValues.SetValues(recipe);
                _context.Entry(oldValues).State = EntityState.Modified;
                
            }
            return oldValues;
        }

        public int CountCategoryRecipes(int categoryId)
        {
            return _context.Recipes.Where(r => r.CategoryId == categoryId).Count();
        }

    }
}
