using MyRecipies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Services
{
    internal interface ICategoriesService
    {
        public List<CategoryDTO> GetAll();
        public CategoryDTO? GetById(int id);
        public CategoryDTO Add(string name);
        public CategoryDTO? Update(CategoryDTO updateDto);
        public void DeleteById(int id);

    }
}
