using Microsoft.EntityFrameworkCore;
using MyRecipies.Exceptions;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Repositories
{
    internal class IngredientsRepository
    {
        private MyrecipesContext _context;

        public IngredientsRepository(MyrecipesContext context)
        {
            _context = context;
        }
        
        public List<Ingredient> GetByName(string name)
        {
            return _context.Ingredients.Where(i => i.IngredientName.StartsWith(name)).ToList();
        }

        public Ingredient? GetOne(int id)
        {
            return _context.Ingredients.FirstOrDefault(i => i.Id == id);
        }

        public Ingredient Add(Ingredient ingredient)
        {
           
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public void DeleteUnassigned()
        {
            var deleteList = _context.Ingredients.Include(i => i.IngredientsRecipes)
                .Where(i => i.IngredientsRecipes.Count == 0).ToList();
            _context.Ingredients.RemoveRange(deleteList);

        }

        public void DeleteOne(int id)
        {
            var ingredient = _context.Ingredients.Find(id);
            if (ingredient is null) throw new EntityNotFoundException("ingredient ");
            _context.Ingredients.Remove(ingredient);

        }
    }
}
