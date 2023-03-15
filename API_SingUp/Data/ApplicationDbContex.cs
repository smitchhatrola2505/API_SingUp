using API_SingUp.Model;
using Microsoft.EntityFrameworkCore;

namespace API_SingUp.Data
{
	public class ApplicationDbContex :DbContext
	{
		public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
			: base(options)
		{
		}
		public DbSet<Singup> Singup { get; set; }

	}
}
