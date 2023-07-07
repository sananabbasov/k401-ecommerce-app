using System;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
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

        public IResult AddCategory(CategoryAddDTO category)
        {
            try
            {
                var test = _categoryDal.AddCategory(category);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryHomeListDTO>> GetCategories(string langcode)
        {
            var result = _categoryDal.GetCategorieByLanguage(langcode);
            return new SuccessDataResult<List<CategoryHomeListDTO>>(result);
        }

        public IDataResult<List<Category>> GetNavbarCategories(string langcode)
        {
            throw new NotImplementedException();

        }

        public IResult UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

