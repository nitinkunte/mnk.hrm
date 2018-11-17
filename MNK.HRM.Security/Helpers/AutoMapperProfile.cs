using AutoMapper;
using MNK.HRM.Security.Dtos;
using MNK.HRM.Security.Entities;

namespace MNK.HRM.Security.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
