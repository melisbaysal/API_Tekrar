using API_Tekrar.DTO_s;
using API_Tekrar.Entities;
using AutoMapper;

namespace API_Tekrar.Mappings
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
			CreateMap<Food, FoodDTO>().ReverseMap();
			CreateMap<Chef, ChefDTO>().ReverseMap();
			CreateMap<Chef, ChefListDTO>().ReverseMap();
			CreateMap<Food, FoodDTO>().ReverseMap();
			CreateMap<Food, FoodListDTO>().ReverseMap();
		}
    }
}
