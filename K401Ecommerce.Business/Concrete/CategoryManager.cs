using System;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static K401Ecommerce.Entities.DTOs.CategoryDTOs.CategoryDTO;

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

        public IDataResult<List<CategoryAdminListDTO>> GetAdminCategoriesByLanguage(string langcode)
        {
            try
            {
                var data = _categoryDal.GetAdminCategoryList(langcode);

                return new SuccessDataResult<List<CategoryAdminListDTO>>(data);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CategoryAdminListDTO>>(ex.Message);
            }
        }

        public IDataResult<List<CategoryHomeListDTO>> GetCategories(string langcode)
        {
            var result = _categoryDal.GetCategorieByLanguage(langcode);
            return new SuccessDataResult<List<CategoryHomeListDTO>>(result);
        }

        public IDataResult<List<CategoryFeaturedHomeDTO>> GetHomeFeaturedCategoriesByLanguage(string langcode)
        {
            try
            {
                var categories = _categoryDal.GetHomeCategoryByLanguage(langcode);
                return new SuccessDataResult<List<CategoryFeaturedHomeDTO>>(categories);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CategoryFeaturedHomeDTO>>(ex.Message);
            }
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

