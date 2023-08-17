using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebUI.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Change(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });


            CookieOptions cookieOptions = new();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Ecommerce", culture, cookieOptions);

            return Redirect(Request.Headers["Referer"].ToString());
        }


        public IActionResult Index(string id, string title)
        {
            var currentURL = Url.PageLink();
            if (id != "Az" && id != "Ru" && id != "Eng")
            {
                return NotFound();
            }
            CookieOptions cookieOptions = new();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Ecommerce", id, cookieOptions);
            return LocalRedirect(title);
        }
    }
}

