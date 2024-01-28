using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.DTO
{
    internal class RecipeSearchDTO
    {
        public string? Name { get; set; }
        public bool? Favourite { get; set; }

        public int? Category { get; set; }
        public string? Position { get; set; }
        public List<int> Ingerdients { get; set; } = new List<int>();
    }
}
