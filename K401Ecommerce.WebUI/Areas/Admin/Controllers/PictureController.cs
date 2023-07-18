using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebUI.Areas.Admin.Controllers
{
    public class PictureController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public PictureController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // GET: /<controller>/
        [HttpPost]
        public JsonResult UploadPicture(List<IFormFile> photoUrl)
        {
            List<string> photoList = new();
            for (int i = 0; i < photoUrl.Count; i++)
            {
                string path = "/uploads/" + Guid.NewGuid() + Path.GetExtension(photoUrl[i].FileName);
                using (var fileStream = new FileStream(_env.WebRootPath+path, FileMode.Create))
                {
                    photoUrl[i].CopyTo(fileStream);
                }
                photoList.Add(path);
            }
            return Json(photoList);
        }
    }
}

