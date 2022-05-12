using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Context;
using DAL.Repository;

namespace BLL.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;
        private IMapper map;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Category, CategoryDTO>()
                    .ForMember(x => x.Id, x => x.MapFrom(category => category.CategoryId))
                    .ForMember(x => x.Name, x => x.MapFrom(category => category.CategoryName)));
            map = new Mapper(config);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return map.Map<IEnumerable<CategoryDTO>>(_categoryRepository.GetAll());
        }

        public CategoryDTO GetById(int id)
        {
            var category = _categoryRepository.GetById(id);

            return map.Map<CategoryDTO>(category);

        }

        public void Update(CategoryDTO category)
        {

            var Edit = _categoryRepository.GetById(category.Id);
            Edit.CategoryName = category.Name;
            _categoryRepository.CreateOrUpdate(Edit);
            _categoryRepository.Save();
        }

        public CategoryDTO Create(CategoryDTO category)
        {
            var newCategory = new Category { CategoryName = category.Name };
            _categoryRepository.CreateOrUpdate(newCategory);
            _categoryRepository.Save();
            category.Id = newCategory.CategoryId;
            return category;

        }
      

    

        public void DeleteById(int Id)
        {
            _categoryRepository.Delete(_categoryRepository.GetById(Id));
        }
        public void Delete(CategoryDTO category)
        {
            
            _categoryRepository.Delete(_categoryRepository.GetById(category.Id));
        }

        public void Save()
        {
            _categoryRepository.Save();
        }
    }
}
