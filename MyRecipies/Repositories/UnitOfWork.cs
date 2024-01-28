using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Repositories
{
    internal class UnitOfWork
    {
        internal CategoriesRepository CategoriesRepository;
        internal IngredientsRecipesRepository IngredientsRecipesRepository;
        internal IngredientsRepository IngredientsRepository;
        internal RecipiesRepository RecipiesRepository;
        private MyrecipesContext _context;

        public UnitOfWork()
        {
            _context = new MyrecipesContext();
            CategoriesRepository = new(_context);
            IngredientsRecipesRepository = new(_context);
            RecipiesRepository = new(_context);
            IngredientsRepository = new(_context);
        }

        public bool SaveChanges()
        {
            var res = _context.SaveChanges();
            if (res == 0) return false;
            else return true;
        }

        public int ExecuteSqlRaw(string query)
        {
            try
            {
                _context.Database.BeginTransaction();
                var result =  _context.Database.ExecuteSqlRaw(query);
                _context.Database.CommitTransaction();
                return result;

            }
            catch(Exception)
            {
                _context.Database.RollbackTransaction();
                return 0;
            }
        }
    }
}
