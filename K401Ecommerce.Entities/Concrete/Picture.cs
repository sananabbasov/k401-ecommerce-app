using System;
namespace K401Ecommerce.Entities.Concrete
{
	public class Picture
	{
		public int Id { get; set; }
		public string PhotoUrl { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}

