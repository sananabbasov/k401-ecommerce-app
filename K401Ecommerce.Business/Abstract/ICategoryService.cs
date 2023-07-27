using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using static K401Ecommerce.Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace K401Ecommerce.Business.Abstract
{
	public interface ICategoryService
	{
        IResult AddCategory(CategoryAddDTO category);
        IResult DeleteCategory(Category category);
        IResult UpdateCategory(Category category);
        IDataResult<List<CategoryAdminListDTO>> GetAdminCategoriesByLanguage(string langcode);
        IDataResult<List<CategoryHomeListDTO>> GetCategories(string langcode);
        IDataResult<List<Category>> GetNavbarCategories(string langcode);
        IDataResult<List<CategoryFeaturedHomeDTO>> GetHomeFeaturedCategoriesByLanguage(string langcode);
        IDataResult<List<CategoryFilterDTO>> GetCategoriesForFilter(string langcode);
    }
}

