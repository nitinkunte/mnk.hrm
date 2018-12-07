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

        public EmployeeModel()
        {
            Prefixes = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Mr.", Value = "Mr."},
                    new SelectListItem(){ Text = "Ms.", Value = "Ms."},
                    new SelectListItem(){ Text = "Mrs.", Value = "Mrs."},
                    new SelectListItem(){ Text = "Dr.", Value = "Dr."},
                 };

            Suffixes = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Please select ...", Value = ""},
                    new SelectListItem(){ Text = "Sr.", Value = "Sr."},
                    new SelectListItem(){ Text = "Jr.", Value = "Jr."},
                 };
        }

        public int Id { get; set; }

        [DisplayName("Prefix")]
        public string Prefix { get; set; }


        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Middle Initial")]
        public string MiddleName { get; set; }

        [DisplayName("Suffix")]
        public string Suffix { get; set; }


        [DisplayName("Employee Id")]
        public string EmployeeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Prefixes { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Suffixes { get; set; }


        public virtual EmployeeAddressModel Address { get; set; }

        public virtual EmployeeJobDetailModel JobDetail { get; set; }

        public virtual EmployeeImmigrationModel Immigration { get; set; }

        public virtual EmployeeDemographicModel Demographic { get; set; }
    }



}
