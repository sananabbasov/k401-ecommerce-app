using System;
namespace K401Ecommerce.Entities.DTOs.CategoryDTOs
{
	public class CategoryAddDTO
	{
		public string PhotoUrl { get; set; }
		public List<string> CategoryName { get; set; }
		public List<string> LangCode { get; set; }
	}
}

