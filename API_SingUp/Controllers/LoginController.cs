using API_SingUp.Data;
using API_SingUp.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API_SingUp.Controllers
{
	[Route("api/login")]
	[ApiController]
	public class LoginController : Controller
	{

		private readonly ApplicationDbContex _context;
		public LoginController(ApplicationDbContex context)
		{
			_context = context;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<LoginDTO>> Login(LoginDTO logiDTO)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}


			var user =  _context.FindUserByEmail(logiDTO.Email);

			if (user == null || !VerifyPassword(user.Password, logiDTO.Password))
			{
				return Unauthorized(); // Invalid login credentials
			}

			return Ok();
		}

		private bool VerifyPassword(string userPassword, string dtoPassword)
		{
			
			for (int i = 0; i < userPassword.Length; i++)
			{
				if (userPassword[i] != dtoPassword[i])
				{
					return false;
				}
			}
			return true;
		}

	}
}
