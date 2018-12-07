using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.DTO
{

    [Table("Employee")]
    public class Employee
    {

        public int Id { get; set; }

        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Suffix { get; set; }

        public string EmployeeId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ? AddressId { get; set; }
        public int ? DemographicId { get; set; }
        public int ? ImmigrationId { get; set; }
        public int ? JobDetailId { get; set; }

        public virtual EmployeeAddress Address { get; set; }

        public virtual EmployeeJobDetail JobDetail { get; set; }

        public virtual EmployeeImmigration Immigration { get; set; }

        public virtual EmployeeDemographic Demographic { get; set; }
    }
}
