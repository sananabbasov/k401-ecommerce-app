using System;
using K401Ecommerce.Core.DataAccess;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;

namespace K401Ecommerce.DataAccess.Abstract
{
	public interface ICategoryDal : IRepositoryBase<Category>
	{
		List<CategoryHomeListDTO> GetCategorieByLanguage(string langcode);
		Task<bool> AddCategory(CategoryAddDTO categoryAddDTO);
	}
}

