using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Infraestructure.Crosscutting.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
