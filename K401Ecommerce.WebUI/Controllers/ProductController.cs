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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            List<int> cats = new();

            cats.Add(3);
            cats.Add(4);
            cats.Add(5);
            var filter = _productService.GetFilterProductsByLanguage("az-Az",0,100000, cats,0,5);
            return View();
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
    }
}

