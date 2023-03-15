using API_SingUp.Data;
using API_SingUp.DTO;
using API_SingUp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_SingUp.Controllers
{
	[Route("api/singUp")]
	[ApiController]
	public class SingupController : ControllerBase
	{
		private readonly ApplicationDbContex _context; 
		public SingupController(ApplicationDbContex context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _context.SingUp.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			return Ok(await _context.SingUp.FirstOrDefaultAsync(c => c.Id == id));
		}

		[HttpPost]
		public async Task<IActionResult> insertProject([FromBody] Singup singup)
		{
			var isExit =  _context.FindUserByData(singup.Email,singup.MobileNumber);

			if(isExit==null)
			{
				await _context.SingUp.AddAsync(singup);
				await _context.SaveChangesAsync();
				return StatusCode(StatusCodes.Status201Created);
			}
			else
			{
				return StatusCode(StatusCodes.Status409Conflict);

			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Singup singup)
		{
			var singupId = await _context.SingUp.FirstOrDefaultAsync(c => c.Id == id);

			singupId.FirstName = singup.FirstName;
			singupId.LastName = singup.LastName;
			singupId.Email = singup.Email;
			singupId.MobileNumber = singup.MobileNumber;
			singupId.Gender = singup.Gender;
			singupId.Address = singup.Address;
			singupId.City = singup.City;
			singupId.Pincode = singup.Pincode;
			singupId.BirthDate = singup.BirthDate;
			singupId.Password = singup.Password;

			_context.SingUp.Update(singupId);
			await _context.SaveChangesAsync();
			return Ok("singup Updated");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var sinupId = await _context.SingUp.FirstOrDefaultAsync(c => c.Id == id);
			_context.SingUp.Remove(sinupId);
			await _context.SaveChangesAsync();
			return Ok("delet successefully");
		}

	}
}
