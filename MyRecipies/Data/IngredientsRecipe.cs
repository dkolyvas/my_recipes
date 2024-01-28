using System;
using System.Collections.Generic;

namespace recipes.Data;

public partial class IngredientsRecipe
{
    public int Id { get; set; }

    public string? Quantity { get; set; }

    public string? Comments { get; set; }

    public int? IngredientId { get; set; }

    public int? RecipeId { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
