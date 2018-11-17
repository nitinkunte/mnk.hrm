using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [DisplayName("Prefix")]
        public string Prefix { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Prefixes { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Middle Initial")]
        public string MiddleName { get; set; }

        [DisplayName("Suffix")]
        public string Suffix { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Suffixes { get; set; }

        [DisplayName("Employee Id")]
        public string EmployeeId { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public virtual EmployeeAddress Address { get; set; }

        public virtual EmployeeJobDetail JobDetail { get; set; }

        public virtual EmployeeImmigration Immigration { get; set; }

        public virtual EmployeeDemographic Demographic { get; set; }
    }
}
