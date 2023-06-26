using System;
namespace K401Ecommerce.Entities.Concrete
{
	public class Order
	{
		public int Id { get; set; }
		public User User { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public decimal ProductPrice { get; set; }
		public int ProductQuantity { get; set; }
		public string Message { get; set; }
	}
}

