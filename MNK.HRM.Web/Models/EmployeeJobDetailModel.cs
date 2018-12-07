using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class EmployeeJobDetailModel
    {
        public EmployeeJobDetailModel()
        {
            PayRateTypes = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Hourly", Value = "Hourly"},
                    new SelectListItem(){ Text = "Yearly", Value = "Yearly"},
                 };

            JobTypes = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Full Time", Value = "Full Time"},
                    new SelectListItem(){ Text = "Part Time", Value = "Part Time"},
                 };
        }

        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [DisplayName("Start Date")]
        public DateTime DateStarted { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [DisplayName("Termination Date")]
        public DateTime? DateTerminated { get; set; }

        [Required]
        [DisplayName("Pay Rate")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid pay rate")]
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
