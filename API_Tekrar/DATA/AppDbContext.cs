using API_Tekrar.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Tekrar.DATA
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}
		public DbSet<Food> Foods { get; set; }
		public DbSet<Chef> Chefs { get; set; }
	}
}
