using AutoMapper;
using MNK.IdentityServer.Dtos;
using MNK.IdentityServer.Entities;

namespace MNK.IdentityServer.Helpers
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