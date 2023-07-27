using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult Index(List<int> cats, int page = 1)
        {

            ViewBag.CurrentPage = page;
            var filter = _productService.GetFilterProductsByLanguage("az-Az",0,100000, cats, page,5);
            var categories = _categoryService.GetCategoriesForFilter("Az");
            ProductFilterVM vm = new()
            {
                ProductFilters = filter.Data.ToList(),
                Categories = categories.Data
            };
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var productDetail = _productService.GetProductDetailById("az-Az",id);

            DetailVM vm = new()
            {
                ProductDetail = productDetail.Data
            };

            return View(vm);
        }



        public JsonResult GetDatas(int take, int page, string categoryList)
        {
            var categories = _categoryService.GetCategoriesForFilter("Az");
            var cats = new List<int>();
            if (categoryList == null)
            {
                cats = categories.Data.Select(x => x.Id).ToList();
            }
            else
            {
                cats = categoryList.Split(",").Select(x => Convert.ToInt32(x)).ToList();
            }
            var test = cats;
            var filter = _productService.GetFilterProductsByLanguage("az-Az", 0, 100000, cats, page, take);
            var productCount = _productService.GetProductCount(take, cats).Data;

            PaginationVM vM = new()
            {
                ProductCount = productCount,
                Products= filter.Data
            };
            return Json(vM);
        }
    }
}

