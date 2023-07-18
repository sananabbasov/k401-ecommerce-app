using System;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using static K401Ecommerce.Entities.DTOs.CategoryDTOs.CategoryDTO;
using static K401Ecommerce.Entities.DTOs.ProductDTOs.ProductDTO;

namespace K401Ecommerce.WebUI.ViewModels
{
	public class HomeVM
	{
		public List<CategoryFeaturedHomeDTO> FeaturedCategories { get; set; }
		public List<ProductFeaturedDTO> ProductFeatured { get; set; }
		public List<ProductRecentDTO> ProductRecent { get; set; }
    }
}

