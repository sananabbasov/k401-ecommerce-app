using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using K401Ecommerce.WebUI.Models;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.WebUI.ViewModels;

namespace K401Ecommerce.WebUI.Controllers;
 
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService)
    {
        _logger = logger;
        _categoryService = categoryService;
        _productService = productService;
    }

    public IActionResult Index()
    {
        var categories = _categoryService.GetHomeFeaturedCategoriesByLanguage("Ru");
        var featuredProducts = _productService.GetAllFeaturedProduct("az-Az");
        var recentProducts = _productService.GetAllRecentProduct("az-Az");
        HomeVM vm = new()
        {
            FeaturedCategories = categories.Data,
            ProductFeatured = featuredProducts.Data,
            ProductRecent = recentProducts.Data

        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

