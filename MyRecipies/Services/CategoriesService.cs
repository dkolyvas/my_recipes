using AutoMapper;

using MyRecipies.DTO;
using MyRecipies.Exceptions;
using MyRecipies.Repositories;
using recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal class CategoriesService: ICategoriesService
    {
        private UnitOfWork _repositories;
        private Mapper _mapper;

        public CategoriesService(UnitOfWork repositories, Mapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        public CategoryDTO Add(string name)
        {
            Category category = new Category()
            {
                CategoryName = name,
            };
            var result = _repositories.CategoriesRepository.Add(category);
            _repositories.SaveChanges();
            
            return _mapper.Map<CategoryDTO>(result);
        }

        public void DeleteById(int id)
        {
            if(_repositories.RecipiesRepository.CountCategoryRecipes(id) > 0)
            {
                throw new UnableToDeleteCategoryException();
            }
            bool result = _repositories.CategoriesRepository.Delete(id);
            if (!result) throw new EntityNotFoundException("category");
            _repositories.SaveChanges();
        }

        public List<CategoryDTO> GetAll()
        {
            var data = _repositories.CategoriesRepository.GetAll();
            return _mapper.Map<List<CategoryDTO>>(data);
        }

        public CategoryDTO? GetById(int id)
        {
            var data = _repositories.CategoriesRepository.Get(id);
            if(data == null) throw new EntityNotFoundException("category");
            return _mapper.Map<CategoryDTO?>(data);
        }

        public CategoryDTO? Update(CategoryDTO updateDto)
        {
            Category updatedCategory = _mapper.Map<Category>(updateDto);
            var result = _repositories.CategoriesRepository.Update(updatedCategory);
            if (result is null) throw new EntityNotFoundException("category");
            _repositories.SaveChanges();
            return _mapper.Map<CategoryDTO>(result);
            
        }
    }
}
