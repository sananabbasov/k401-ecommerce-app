using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using K401Ecommerce.WebUI.Models;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.WebUI.Controllers;
 
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICategoryService _categoryService;

    public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var categories = _categoryService.GetCategories("Ru");
        return View(categories.Data);
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

