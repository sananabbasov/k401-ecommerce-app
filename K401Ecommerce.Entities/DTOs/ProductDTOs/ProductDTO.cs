using System;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.Entities.DTOs.ProductDTOs
{
    public class ProductDTO
    {
		public record ProductAddDTO(decimal Price, decimal Discount, int Quantity, int CategoryId,string UserId, bool IsFeatured, List<string> Name,List<string> Description, List<string> LangCode, List<string> photoUrls);
		public record ProductFeaturedDTO(int Id, string Name, string PhotoUrl, decimal Price, decimal Discount, string SeoUrl);
		public record ProductRecentDTO(int Id, string Name, string PhotoUrl, decimal Price, decimal Discount, string SeoUrl);
    }
}

