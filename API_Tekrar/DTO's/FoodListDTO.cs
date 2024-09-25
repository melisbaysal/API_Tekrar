using API_Tekrar.Entities;

namespace API_Tekrar.DTO_s
{
	public class FoodListDTO
	{
		public string Name { get; set; }
		public int ProperationTime { get; set; }
		public ChefDTO ChefDTO { get; set; }
		public int ChefId { get; set; }
	}
}
