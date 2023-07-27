using System;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using K401Ecommerce.Entities.DTOs.ProductDTOs;

namespace K401Ecommerce.WebUI.ViewModels
{
	public class ProductFilterVM
	{
		public List<ProductFilterDTO> ProductFilters { get; set; }
		public List<CategoryFilterDTO> Categories { get; set; }
	}
}

