using MyRecipies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal interface IRecipiesService
    {
        public List<RecipeReadOnlyDTO> FindRecipes(RecipeSearchDTO searchCriteria);
        public List<IngredientsRecReadOnlyDTO> FindIngredients(int recipeId);

        public RecipeReadOnlyDTO FindRecipe(int id);

        public RecipeReadOnlyDTO AddRecipe(RecipeInsertDTO insertDto, List<IngredientsRecInsertDTO> newIngredients);

        public RecipeReadOnlyDTO UpdateRecipe(RecipeUpdateDTO updateDto, List<IngredientsRecInsertDTO> newIngredients,
            List<IngredientsRecUpdateDTO> updateIngredients, List<int> deleteIngredients);

        public bool DeleteRecipes(List<int> deleteList);

        public bool DeleteRecipe(int id);
    }
}
