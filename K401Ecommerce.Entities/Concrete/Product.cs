using System;
namespace K401Ecommerce.Entities.Concrete
{
	public class Product
	{
		public int Id { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public decimal Raiting { get; set; }
		public int Views { get; set; }
		public int Quantity { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
		public bool IsFeatured { get; set; }
	}
}

