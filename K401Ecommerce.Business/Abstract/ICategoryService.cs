using System;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;

namespace K401Ecommerce.Business.Abstract
{
	public interface ICategoryService
	{
		void AddCategory(CategoryAddDTO category);
		void DeleteCategory(Category category);
		void UpdateCategory(Category category);
        List<CategoryHomeListDTO> GetCategories(string langcode);
        List<Category> GetNavbarCategories(string langcode);
    }
}

