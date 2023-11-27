using AutoMapper;
namespace MyDatePlanningApi.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Users.CreateUser, MyDatePlanningData.Entities.User>();
            CreateMap<Users.UpdateUser, MyDatePlanningData.Entities.User>();
        }
    }
}
