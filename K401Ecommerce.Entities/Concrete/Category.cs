using System;
namespace K401Ecommerce.Entities.Concrete
{
	public class Category
	{
		public int Id { get; set; }
		public string PhotoUrl { get; set; }
		public bool IsFeatured { get; set; }
		public List<CategoryLanguage> CategoryLanguages { get; set; }
	}
}

