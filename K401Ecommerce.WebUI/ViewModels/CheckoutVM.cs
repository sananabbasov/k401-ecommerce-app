using System;
using K401Ecommerce.Entities.Concrete;
using K401Ecommerce.Entities.DTOs.CartDTOs;

namespace K401Ecommerce.WebUI.ViewModels
{
    public class CheckoutVM
    {
        public User User { get; set; }
        public List<UserCartDTO> CartItems { get; set; }
    }
}

