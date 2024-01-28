using System;
using System.Collections.Generic;

namespace recipes.Data;

public partial class Ingredient
{
    public string IngredientName { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<IngredientsRecipe> IngredientsRecipes { get; set; } = new List<IngredientsRecipe>();
}
