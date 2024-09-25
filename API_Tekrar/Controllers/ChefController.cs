using API_Tekrar.DATA;
using API_Tekrar.DTO_s;
using API_Tekrar.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Tekrar.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ChefController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public ChefController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> AddChef(ChefDTO chef)
		{
			await _context.Chefs.AddAsync(_mapper.Map<Chef>(chef));
			await _context.SaveChangesAsync();
			return Ok(chef);
		}
		[HttpGet]

		public async Task<IActionResult> GetAllChefs()
		{
			var chefs = await _context.Chefs.ToListAsync();
			var allChef = _mapper.Map<List<ChefListDTO>>(chefs);
			return Ok(allChef);
		}

		[HttpPut("{id}")]

		public async Task<IActionResult> UpdateChef(int id, ChefDTO updatedChef)
		{
			var chef = await _context.Chefs.FindAsync(id);
			if (chef == null)
			{
				return NotFound();
			}

			chef.Name = updatedChef.Name;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpGet]

		public async Task<IActionResult> GetChefById(int id)
		{
			var chef = await _context.Chefs.Include(x => x.Foods).FirstOrDefaultAsync(x => x.Id == id);
			return Ok(_mapper.Map<ChefListDTO>(chef));
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> DeleteChef(int id)
		{
			var chef = await _context.Chefs.FindAsync(id);
			if(chef == null)
			{
				return NotFound();
			}
			_context.Chefs.Remove(chef);
			await _context.SaveChangesAsync();
			return NoContent();
		} 

	}
}
