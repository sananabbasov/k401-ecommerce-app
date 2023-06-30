using System;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;

namespace K401Ecommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(CategoryAddDTO category)
        {
            _categoryDal.AddCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<CategoryHomeListDTO> GetCategories(string langcode)
        {
            return _categoryDal.GetCategorieByLanguage(langcode);
        }

        public List<Category> GetNavbarCategories(string langcode)
        {
            throw new NotImplementedException();

        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

