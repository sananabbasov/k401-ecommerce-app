using System;
namespace K401Ecommerce.Entities.DTOs.CategoryDTOs
{
	public class CategoryHomeListDTO
	{

		public int Id { get; set; }
		public string CategoryName { get; set; }
		public string SeoUrl { get; set; }
		public int ProductCount { get; set; }
		public string PhotoUrl { get; set; }
	}
}

