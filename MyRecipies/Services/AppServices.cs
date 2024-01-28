using AutoMapper;
using MyRecipies.Repositories;
using MyRecipies.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal class AppServices: IAppServices
    {
        private Mapper _mapper = MapperConfig.InitializeMapper();
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public ICategoriesService CategoriesService => new CategoriesService(_unitOfWork, _mapper);

        public IIngredientsService IngredientsService => new IngredientsService(_unitOfWork, _mapper);

        public IRecipiesService RecipiesService => new RecipiesService(_mapper, _unitOfWork);
    }
}
