using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Entities.DTOs.CartDTOs;
using K401Ecommerce.Entities.DTOs.OrderDTOs;
using K401Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K401Ecommerce.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public CartController(IHttpContextAccessor httpContext, IProductService productService, IUserService userService, IOrderService orderService)
        {
            _httpContext = httpContext;
            _productService = productService;
            _userService = userService;
            _orderService = orderService;
        }

        public JsonResult AddToCart(string id, int quantity)
        {

            var check = Request.Cookies["cart"];


            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";
            List<CartCookieDTO> cartCookies = new();

            CartCookieDTO cookieDTO = new()
            {
                Id = Convert.ToInt32(id),
                Quantity = quantity
            };
            if (check == null)
            {

                cartCookies.Add(cookieDTO);
                var cookieJson = JsonSerializer.Serialize<List<CartCookieDTO>>(cartCookies);
                Response.Cookies.Append("cart", cookieJson, cookieOptions);
            }
            else
            {
                var data = JsonSerializer.Deserialize<List<CartCookieDTO>>(check);
                var findData = data.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
                if (findData != null)
                {
                    findData.Quantity += 1;
                }
                else
                {
                    data.Add(cookieDTO);
                }
                var cookieJson = JsonSerializer.Serialize<List<CartCookieDTO>>(data);
                Response.Cookies.Append("cart", cookieJson, cookieOptions);

            }


            return Json("akldfsasl");
        }


        public JsonResult GetProduct()
        {
            var check = Request.Cookies["cart"];
            var data = JsonSerializer.Deserialize<List<CartCookieDTO>>(check);
            var quantity = data.Select(x => x.Quantity).ToList();
            var dataIds = data.Select(x => x.Id).ToList();
            var result = _productService.GetProductForCart(dataIds, "az-Az", quantity);
            return Json(result);
        }


        public JsonResult RemoveProduct(int id)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";

            var check = Request.Cookies["cart"];

            var data = JsonSerializer.Deserialize<List<CartCookieDTO>>(check);

            var findData = data.FirstOrDefault(x => x.Id == Convert.ToInt32(id));

            data.Remove(findData);

            var cookieJson = JsonSerializer.Serialize<List<CartCookieDTO>>(data);
            Response.Cookies.Append("cart", cookieJson, cookieOptions);
            return Json("ok");
        }


        public JsonResult AddQuantity(int id)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";

            var check = Request.Cookies["cart"];

            var data = JsonSerializer.Deserialize<List<CartCookieDTO>>(check);

            var findData = data.FirstOrDefault(x => x.Id == Convert.ToInt32(id));

            findData.Quantity += 1;

            //var cookieJson = JsonSerializer.Serialize<List<CartCookieDTO>>(data);
            //Response.Cookies.Append("cart", cookieJson, cookieOptions);
            return Json("ok");
        }

        public IActionResult UserCart()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");

            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            var user = _userService.GetUserById(userId).Data;

            var check = Request.Cookies["cart"];
            var data = JsonSerializer.Deserialize<List<CartCookieDTO>>(check);
            var quantity = data.Select(x => x.Quantity).ToList();
            var dataIds = data.Select(x => x.Id).ToList();
            var result = _productService.GetProductForCart(dataIds, "az-Az", quantity).Data;

            CheckoutVM vm = new()
            {
                User = user,
                CartItems = result
            };

            return View(vm);
        }


        [HttpPost]
        public IActionResult Checkout(string id)
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var check = Request.Cookies["cart"];
            var data = JsonSerializer.Deserialize<List<CartCookieDTO>>(check);
            var quantity = data.Select(x => x.Quantity).ToList();
            var dataIds = data.Select(x => x.Id).ToList();
            var result = _productService.GetProductForCart(dataIds, "az-Az", quantity).Data;

            List<CreateOrderDTO> createOrders = new();

            foreach (var cartItem in result)
            {
                CreateOrderDTO orderDTO = new()
                {
                    UserId = userId,
                    ProductId = cartItem.Id,
                    ProductPrice = cartItem.Price,
                    ProductQuantity = cartItem.Quantity,
                    Message = "Yoxdu"
                };
                createOrders.Add(orderDTO);
            }

            _orderService.CreateOrder(createOrders);
            return RedirectToAction("Index", "Home");
        }

    }
}

