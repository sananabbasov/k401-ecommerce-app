using System;
namespace K401Ecommerce.Entities.DTOs.ProductDTOs
{
	public class ProductFilterDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string SeoUrl { get; set; }
		public string PhotoUrl { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
	}
}

