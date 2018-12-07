using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class EmployeeAddressModel
    {

        public int Id { get; set; }

        [DisplayName("Address Line 1")]
        public string Address1 { get; set; }

        [DisplayName("Address Line 2")]
        public string Address2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> States { get; set; }

        [DisplayName("Postal Code")]
        public string ZipCode { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [DisplayName("Home Phone #")]
        public string PhoneHome { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [DisplayName("Cell Phone #")]
        public string PhoneCell { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Personal Email")]
        public string EmailPersonal { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Work Email")]
        public string EmailWork { get; set; }

    }
}
