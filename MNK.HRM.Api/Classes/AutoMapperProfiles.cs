using System;
using AutoMapper;
using MNK.HRM.Api.Classes;
using MNK.HRM.Api.Models;
using MNK.HRM.Security.Dtos;
using MNK.HRM.Security.Entities;

namespace MNK.HRM.Api.Classes
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDatum>()
                .ForMember(s => s.DT_RowData, o => o.Ignore())
                .ForMember(s => s.DT_RowId, o => o.Ignore())
                .ReverseMap();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
