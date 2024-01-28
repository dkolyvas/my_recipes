using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.DTO
{
    internal class RecipeReadOnlyDTO
    {
        public string? RecipeName { get; set; }

        public string? Position { get; set; }

        public bool Favourite { get; set; }

        public string? Implementation { get; set; }

        public bool Made { get; set; }

        public int CategoryId { get; set; }

        public int Id { get; set; }

        public string? CategoryName { get; set; }
    }
}
