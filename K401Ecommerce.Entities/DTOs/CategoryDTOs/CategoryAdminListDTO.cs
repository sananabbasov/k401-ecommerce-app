using System;
namespace K401Ecommerce.Entities.DTOs.CategoryDTOs
{
	public class CategoryAdminListDTO
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public string PhotoUrl { get; set; }
		public int ProductCount { get; set; }
        public bool IsFeatured { get; set; }
    }
}

