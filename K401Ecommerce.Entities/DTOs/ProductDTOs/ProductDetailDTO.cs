using System;
namespace K401Ecommerce.Entities.DTOs.ProductDTOs
{
	public class ProductDetailDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<string> PhotoUrls { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public string Description { get; set; }
		public string SeoUrl { get; set; }
	}
}

