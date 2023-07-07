using System;
namespace K401Ecommerce.Entities.DTOs.ProductDTOs
{
	public class ProductAdminListDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public string PhotoUrl { get; set; }
		public int View { get; set; }
		public string CategoryName { get; set; }
	}
}

