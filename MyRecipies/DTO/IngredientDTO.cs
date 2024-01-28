using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.DTO
{
    internal class IngredientDTO
    {
        
        public string IngredientName { get; set; } = null!;

        public int Id { get; set; }

        public IngredientDTO() { }

    }
}
