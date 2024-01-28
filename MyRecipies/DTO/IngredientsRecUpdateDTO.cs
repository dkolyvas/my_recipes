using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.DTO
{
    internal class IngredientsRecUpdateDTO
    {
        public int Id { get; set; }

        public string? Quantity { get; set; }

        public string? Comments { get; set; }

        public int? IngredientId { get; set; }

        public int? RecipeId { get; set; }
    }
}
