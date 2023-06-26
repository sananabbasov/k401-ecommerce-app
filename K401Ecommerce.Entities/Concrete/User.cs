using System;
using K401Ecommerce.Core.Entities;

namespace K401Ecommerce.Entities.Concrete
{
	public class User : AppUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
	}
}

