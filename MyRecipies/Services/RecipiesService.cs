using AutoMapper;

using MyRecipies.DTO;
using MyRecipies.Exceptions;
using MyRecipies.Repositories;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal class RecipiesService: IRecipiesService
    {
        private Mapper _mapper;
        private UnitOfWork _repositories;

        public RecipiesService(Mapper mapper, UnitOfWork repositories)
        {
            _mapper = mapper;
            _repositories = repositories;
        }

        public RecipeReadOnlyDTO AddRecipe(RecipeInsertDTO insertDto, List<IngredientsRecInsertDTO> newIngredients)
        {
            Recipe inputData = _mapper.Map<Recipe>(insertDto);
            var recipe = _repositories.RecipiesRepository.Add(inputData);
            if (recipe is null) throw new Exception("Error adding recipe");
            foreach( var item in newIngredients )
            {
                item.RecipeId = recipe.Id;
            }
            List<IngredientsRecipe> recipeIngredients = _mapper.Map<List<IngredientsRecipe>>(newIngredients);
            /* foreach( var item in recipeIngredients)
             {
                 var inserted = _repositories.IngredientsRecipesRepository.Add(item);

             */
            if (recipeIngredients.Count > 0)
            {
                recipeIngredients = _repositories.IngredientsRecipesRepository.AddRange(recipeIngredients);
                bool isSaved = _repositories.SaveChanges();
                if (!isSaved) throw new DatabaseErrorException();
            }
            
            
            recipe = _repositories.RecipiesRepository.GetOne(recipe.Id);
            return _mapper.Map<RecipeReadOnlyDTO>(recipe);
        }

        public bool DeleteRecipe(int id)
        {
            bool result = _repositories.RecipiesRepository.Delete(id);
            if (!result) throw new EntityNotFoundException("recipe");
            result = _repositories.SaveChanges();
            if (!result) throw new DatabaseErrorException();
            return result;
        }

        public bool DeleteRecipes(List<int> deleteList)
        {
            List<int> notFoundList = new();
            foreach(int i in deleteList)
            {
                bool isFound = _repositories.RecipiesRepository.Delete(i);
                if(!isFound) notFoundList.Add(i);
            }
            bool isSaved = _repositories.SaveChanges();
            if(!isSaved) throw new DatabaseErrorException();
            if(notFoundList.Count > 0)
            {
                string notFoundString = "";
                foreach(int i in notFoundList)
                {
                    notFoundString += i + " ";
                }
                throw new EntityNotFoundException($"recipies wit id  {notFoundString}");

            }
            return true;
        }

        public List<IngredientsRecReadOnlyDTO> FindIngredients(int recipeId)
        {
            var data = _repositories.IngredientsRecipesRepository.GetRecipeIngredients(recipeId);
            return _mapper.Map<List<IngredientsRecReadOnlyDTO>>(data);
        }

        public RecipeReadOnlyDTO FindRecipe(int id)
        {
            var recipe = _repositories.RecipiesRepository.GetOne(id);
            if (recipe is null) throw new EntityNotFoundException("recipe");
            return _mapper.Map<RecipeReadOnlyDTO>(recipe);
        }

        public List<RecipeReadOnlyDTO> FindRecipes(RecipeSearchDTO searchCriteria)
        {
            var data = _repositories.RecipiesRepository.GetList(searchCriteria);
            return _mapper.Map<List<RecipeReadOnlyDTO>>(data);
        }

        public RecipeReadOnlyDTO UpdateRecipe(RecipeUpdateDTO updateDto, List<IngredientsRecInsertDTO> newIngredients, List<IngredientsRecUpdateDTO> updateIngredients, List<int> deleteIngredients)
        {
            var updatedRecipe = _mapper.Map<Recipe>(updateDto);
            var recipe = _repositories.RecipiesRepository.Update(updatedRecipe);
            if(recipe is null) throw new EntityNotFoundException("recipe");

            foreach(var item in newIngredients)
            {
                item.RecipeId = recipe.Id;
                var currIngr = _mapper.Map<IngredientsRecipe>(item);
                currIngr = _repositories.IngredientsRecipesRepository.Add(currIngr);
            }

            foreach(var item in updateIngredients)
            {
                var currIngr = _mapper.Map<IngredientsRecipe>(item);
                currIngr = _repositories.IngredientsRecipesRepository.Update(currIngr);
                if(currIngr is null) throw new EntityNotFoundException("ingredient with id " + item.Id);
            }

            foreach(var item in deleteIngredients)
            {
                bool isDeleted = _repositories.IngredientsRecipesRepository.Delete(item);
                if (!isDeleted) throw new EntityNotFoundException("ingredient with id " + item);
            }

            var isSaved = _repositories.SaveChanges();
            if (!isSaved) throw new DatabaseErrorException();

            var result = _repositories.RecipiesRepository.GetOne(recipe.Id);
            return _mapper.Map<RecipeReadOnlyDTO>(result);

        }
    }
}
