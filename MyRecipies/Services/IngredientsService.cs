using AutoMapper;

using MyRecipies.DTO;
using MyRecipies.Exceptions;
using MyRecipies.Repositories;
using MyRecipies.Utilities;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal class IngredientsService : IIngredientsService
    {
        private UnitOfWork _repositories;
        private Mapper _mapper;

        public IngredientsService(UnitOfWork repositories, Mapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
            
            
        }

        public IngredientDTO Add(string name)
        {
            Ingredient newIngredient = new()
            {
                IngredientName = name,
            };
            var result =_repositories.IngredientsRepository.Add(newIngredient);
            return _mapper.Map<IngredientDTO>(result);
            
        }

        public void DeleteUnassigned()
        {
            _repositories.IngredientsRepository.DeleteUnassigned();
            _repositories.SaveChanges();
        }

        public IngredientDTO? GetById(int id)
        {
            var ingredient = _repositories.IngredientsRepository.GetOne(id);
            if(ingredient == null)  throw new EntityNotFoundException("ingredient"); 
            return _mapper.Map<IngredientDTO>(ingredient);
        }

        public List<IngredientDTO> GetByName(string name)
        {
            var resultList = _repositories.IngredientsRepository.GetByName(name);
            return _mapper.Map<List<IngredientDTO>>(resultList);
        }

        public int ReplaceIngredient(int oldIngredient, int newIngredient)
        {
            string query = $"UPDATE INGREDIENTS_RECIPES SET INGREDIENT_ID = {newIngredient} " +
                $"WHERE INGREDIENT_ID = {oldIngredient}";
            var result = _repositories.ExecuteSqlRaw(query);
            
            _repositories.IngredientsRepository.DeleteOne(oldIngredient);
            _repositories.SaveChanges();
            return result;
        }
    }
}
