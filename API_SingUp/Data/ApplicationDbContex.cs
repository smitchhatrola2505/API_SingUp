using API_SingUp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace API_SingUp.Data
{
	public class ApplicationDbContex :DbContext
	{
		public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
			: base(options)
		{
		}
		public DbSet<Singup> SingUp { get; set; }

		public Singup FindUserByEmail(string email)
		{
			return SingUp.SingleOrDefault(u => u.Email == email);
		}

		

	}
}
