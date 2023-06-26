using System;
namespace K401Ecommerce.Entities.Concrete
{
	public class ProductLanguage
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string LangCode { get; set; }
		public string SeoUrl { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}

