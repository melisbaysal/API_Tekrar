namespace API_Tekrar.Entities
{
	public class Food
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProperationTime { get; set; }
        public Chef Chef { get; set; }
        public int ChefId { get; set; }
    }
}
