using System;
namespace K401Ecommerce.Entities.DTOs.CategoryDTOs
{
	public class CategoryDTO
	{
		public record CategoryFeaturedHomeDTO(int Id, string CategoryName, int ProductCount, string PhotoUrl,string SeoUrl);
		public record CategoryEditDTO(int Id, string PhotoUrl,bool IsFeatured, List<CategoryLanguageEditDTO> CategoryLanguages);
		public record CategoryLanguageEditDTO(int Id, string CategoryName, string LangCode, string SeoUrl, int CategoryId);
	}
}

