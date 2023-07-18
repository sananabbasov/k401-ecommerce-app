using System;
namespace K401Ecommerce.Entities.DTOs.CategoryDTOs
{
	public class CategoryUpdateDTO
	{
		public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsFeatured { get; set; }
        public List<string> CategoryName { get; set; }
	}
}

