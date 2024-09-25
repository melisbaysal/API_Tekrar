using API_Tekrar.Entities;
using System.Text.Json.Serialization;

namespace API_Tekrar.DTO_s
{
	public class FoodDTO
	{

		public string Name { get; set; }
		public int ProperationTime { get; set; }		
		public int ChefId { get; set; }
	}
}
