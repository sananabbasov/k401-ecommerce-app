using System;
using K401Ecommerce.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace K401Ecommerce.WebUI.ViewComponents
{
	public class ProductFilterViewComponent : ViewComponent
	{
		private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductFilterViewComponent(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<int> cats, int page = 1)
		{
            var categories = _categoryService.GetCategoriesForFilter("Az");
            var catIds = categories.Data.Select(x => x.Id).ToList();
            var filter = _productService.GetFilterProductsByLanguage("az-Az", 0, 100000, catIds, page, 5);
            return View("ProductFilter", filter.Data);
		}
	}
}

