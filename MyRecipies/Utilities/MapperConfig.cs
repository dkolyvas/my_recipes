using AutoMapper;
using recipes.Data;
using MyRecipies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Utilities
{
    internal class MapperConfig
    {
        public static Mapper InitializeMapper() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeInsertDTO>().ReverseMap();
                cfg.CreateMap<Recipe, RecipeUpdateDTO>().ReverseMap();
                cfg.CreateMap<Recipe, RecipeReadOnlyDTO>().ForMember(d => d.CategoryName, f => f.MapFrom(s => s.Category.CategoryName)).ReverseMap();
                cfg.CreateMap<IngredientsRecipe, IngredientsRecInsertDTO>().ReverseMap();
                cfg.CreateMap<IngredientsRecipe, IngredientsRecUpdateDTO>().ReverseMap();
                cfg.CreateMap<IngredientsRecipe, IngredientsRecReadOnlyDTO>().ForMember(d => d.IngredientName, f => f.MapFrom(s => s.Ingredient.IngredientName))
                    .ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Ingredient, IngredientDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
    }
}
