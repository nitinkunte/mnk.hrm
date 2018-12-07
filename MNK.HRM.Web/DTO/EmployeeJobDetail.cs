using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.DTO
{
    [Table("EmployeeJobDetail")]
    public class EmployeeJobDetail
    {

        [ForeignKey("Employee")]
        public int Id { get; set; }

        //public int EmployeeId { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        public DateTime? DateTerminated { get; set; }

        public decimal PayRate { get; set; }

        public string PayRateType { get; set; }

        [Required]
        public bool IsEligibleForVacation { get; set; }

        [Required]
        public string JobType { get; set; }
 
        public string JobTitle { get; set; }



    }
}
