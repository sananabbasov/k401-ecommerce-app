using System;
using K401Ecommerce.Core.DataAccess;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using static K401Ecommerce.Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace K401Ecommerce.DataAccess.Abstract
{
	public interface ICategoryDal : IRepositoryBase<Category>
	{
		List<CategoryHomeListDTO> GetCategorieByLanguage(string langcode);
		List<CategoryAdminListDTO> GetAdminCategoryList(string langcode);
		Task<bool> AddCategory(CategoryAddDTO categoryAddDTO);
		List<CategoryFeaturedHomeDTO> GetHomeCategoryByLanguage(string langcode);
		List<CategoryFilterDTO> GetFilterCategories(string langcode);
	}
}

