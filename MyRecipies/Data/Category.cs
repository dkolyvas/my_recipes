using System;
using System.Collections.Generic;

namespace recipes.Data;

public partial class Category
{
    public string CategoryName { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
