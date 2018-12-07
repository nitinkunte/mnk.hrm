using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class EmployeeModel
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        //public int AddressId { get; set; }
        //public int JobDetailId { get; set; }
        //public int DemographicId { get; set; }
        //public int ImmigrationId { get; set; }

        public virtual EmployeeAddressModel Address { get; set; }

        public virtual EmployeeJobDetailModel JobDetail { get; set; }

        public virtual EmployeeImmigrationModel Immigration { get; set; }

        public virtual EmployeeDemographicModel Demographic { get; set; }
    }



}
