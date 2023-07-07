using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K401Ecommerce.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/values
        [HttpGet("getall/{langcode}")]
        public IActionResult Get(string langcode)
        {
            var categories = _categoryService.GetCategories(langcode);
            return Ok(categories);
        }

       
    }
}

