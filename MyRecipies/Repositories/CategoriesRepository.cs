using Microsoft.EntityFrameworkCore;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Repositories
{
    internal class CategoriesRepository
    {
        private MyrecipesContext _context;

        public CategoriesRepository(MyrecipesContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();

        }
        public Category? Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category? Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null) return false;
            _context.Categories.Remove(category);
            return true;
        }

        public Category? Update(Category category)
        {
            var categoryToUpdate = _context.Categories.Find(category.Id);
            if (categoryToUpdate is not null) 
            {
                _context.Entry(categoryToUpdate).CurrentValues.SetValues(category);
                _context.Entry(categoryToUpdate).State = EntityState.Modified;
            }
            return categoryToUpdate;
        }
    }
}
