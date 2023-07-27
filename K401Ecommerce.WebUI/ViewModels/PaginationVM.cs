using System;
using K401Ecommerce.Entities.DTOs.ProductDTOs;

namespace K401Ecommerce.WebUI.ViewModels
{
	public class PaginationVM
	{
		public int ProductCount { get; set; }
		public IEnumerable<ProductFilterDTO> Products { get; set; }
	}
}

