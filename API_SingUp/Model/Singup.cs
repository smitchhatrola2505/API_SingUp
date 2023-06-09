﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace API_SingUp.Model
{
	public class Singup
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string MobileNumber { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public int Pincode { get; set; }
		public string Gender { get; set; }
		public DateTime BirthDate { get; set; }
		public string Password { get; set; }

	}
}
