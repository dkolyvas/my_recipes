using System;
using System.Collections.Generic;

namespace recipes.Data;

public partial class Recipe
{
    public string? RecipeName { get; set; }

    public string? Position { get; set; }

    public bool Favourite { get; set; }

    public string? Implementation { get; set; }

    public bool Made { get; set; }

    public int CategoryId { get; set; }

    public int Id { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<IngredientsRecipe> IngredientsRecipes { get; set; } = new List<IngredientsRecipe>();
}
