using System;
using AutoMapper;
using MNK.HRM.Api.Classes;
using MNK.HRM.Api.Models;

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

        }
    }
}
