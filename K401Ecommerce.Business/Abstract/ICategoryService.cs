using System;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.Business.Abstract
{
	public interface ICategoryService
	{
		void AddCategory(Category category);
		void DeleteCategory(Category category);
		void UpdateCategory(Category category);
        List<Category> GetCategories(string langcode);
        List<Category> GetNavbarCategories(string langcode);
    }
}

