using System;
using AutoMapper;
using MNK.HRM.Web.Models;
using MNK.HRM.Web.DTO;

namespace MNK.HRM.Web.Classes
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EmployeeModel, Employee>()
                .ReverseMap();

            CreateMap<EmployeeAddressModel, EmployeeAddress>()
                .ReverseMap();

            CreateMap<EmployeeJobDetailModel, EmployeeJobDetail>()
                .ReverseMap();

            CreateMap<EmployeeImmigrationModel, EmployeeImmigration>()
                .ReverseMap();

            CreateMap<EmployeeDemographicModel, EmployeeDemographic>()
                .ReverseMap();
                
        }
    }
}
