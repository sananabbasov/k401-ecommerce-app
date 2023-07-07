using System;
namespace K401Ecommerce.Entities.DTOs.UserDTOs
{
	public class UserRegisterDTO
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PasswordRepeat { get; set; }
		public string Address { get; set; }
	}
}

