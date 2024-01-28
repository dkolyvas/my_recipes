using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal interface IAppServices
    {
        public ICategoriesService CategoriesService { get; }
        public IIngredientsService IngredientsService { get; }

        public IRecipiesService RecipiesService { get; }
    }
}
