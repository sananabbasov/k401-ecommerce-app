using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using K401Ecommerce.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static K401Ecommerce.Entities.DTOs.ProductDTOs.ProductDTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor, ICategoryService categoryService)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _productService.GetDashboardProducts("Az",userId);
            return View(result.Data);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.GetHomeFeaturedCategoriesByLanguage("Az");
            ViewBag.Categories = new SelectList(categories.Data ,"Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductAddDTO productAddDTO)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _productService.AddDasboardProduct(productAddDTO, userId);
            return RedirectToAction("Index");
        }
    }
}

