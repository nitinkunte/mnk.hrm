using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Api.Models
{
    public class EmployeeJobDetail
    {

        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Start Date")]
        public DateTime DateStarted { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [DisplayName("Termination Date")]
        public DateTime? DateTerminated { get; set; }

        [Required]
        [DisplayName("Pay Rate")]
        public decimal PayRate { get; set; }

        [Required]
        [DisplayName("Pay Rate Type")]
        public string PayRateType { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> PayRateTypes { get; set; }

        [Required]
        [DisplayName("Is eligible for Vacation?")]
        public bool IsEligibleForVacation { get; set; }

        [Required]
        [DisplayName("Job Type")]
        public string JobType { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> JobTypes { get; set; }

        [DisplayName("Job Title")]
        public string JobTitle { get; set; }



    }
}
