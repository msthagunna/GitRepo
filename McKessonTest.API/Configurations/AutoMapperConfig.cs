using AutoMapper;
using McKessonTest.API.Data;
using McKessonTest.API.Models;

namespace McKessonTest.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LocationModel, Location>().ReverseMap();
        }
    }
}
