using System;
using System.Security.Claims;
using K401Ecommerce.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace K401Ecommerce.WebUI.ViewComponents
{
	public class UserAuthViewComponent : ViewComponent
	{
		private readonly IHttpContextAccessor _httpContext;
		private readonly UserManager<User> _userManager;

        public UserAuthViewComponent(IHttpContextAccessor httpContext, UserManager<User> userManager)
        {
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var user = await _userManager.FindByIdAsync(userId);
			return View("UserAuth",user);
		}
	}
}

