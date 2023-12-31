﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _categoryService.GetAdminCategoriesByLanguage("Az");
            return View(categories.Data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryAddDTO category)
        {
            var result = _categoryService.AddCategory(category);
            if (result.Success)
                return RedirectToAction("Index");
            return View(category);
        }
    }
}

