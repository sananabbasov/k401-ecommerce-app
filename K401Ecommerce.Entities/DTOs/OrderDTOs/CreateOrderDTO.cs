using System;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.Entities.DTOs.OrderDTOs
{
	public class CreateOrderDTO
	{
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string Message { get; set; }
    }
}

