using API_Tekrar.DATA;
using API_Tekrar.DTO_s;
using API_Tekrar.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Tekrar.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public FoodController(AppDbContext context,IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
		}
		[HttpPost("{chefId}")]
		public async Task<IActionResult> AddFood(FoodDTO foodDTO,int chefId)
		{
			foodDTO.ChefId = chefId;
			await _context.Foods.AddAsync(_mapper.Map<Food>(foodDTO));
			await _context.SaveChangesAsync();
			return Ok(foodDTO);

		}

		[HttpGet]
		public async Task<IActionResult> GetAllFoods()
		{
			var foods = await _context.Foods.ToListAsync();
			var allFoods = _mapper.Map<List<FoodDTO>>(foods);
			return Ok(allFoods);
		}

		[HttpPut("{id}")]

		public async Task<IActionResult> UpdateFood(int id,FoodDTO foodToUpdate)
		{
			var food = await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);
			food.Name = foodToUpdate.Name;
			food.ProperationTime = foodToUpdate.ProperationTime;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> GetFoodById(int id)
		{
			var food = await _context.Foods.Include(x => x.Chef).FirstOrDefaultAsync(x => x.Id == id);
			return Ok(food);
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> DeleteFood(int id)
		{
			var food = await _context.Foods.FindAsync(id);
			if (food == null)
			{
				return NotFound();
			}
			 _context.Foods.Remove(food);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
