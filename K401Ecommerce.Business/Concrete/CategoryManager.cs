using System;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.GetAll();
            _categoryDal.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories(string langcode)
        {
            throw new NotImplementedException();
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

