using MyRecipies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal interface IIngredientsService
    {
        public List<IngredientDTO> GetByName(string name);
        public IngredientDTO? GetById(int id);
        public void DeleteUnassigned();
        public IngredientDTO Add(string name);
        public int ReplaceIngredient(int oldIngredient, int newIngredient);
    }
}
