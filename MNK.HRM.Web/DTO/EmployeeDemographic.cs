using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.DTO
{
    [Table("EmployeeDemographic")]
    public class EmployeeDemographic
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

        //public int EmployeeId { get; set; }

        [Required]
        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        [Required]
        public string Ethnicity { get; set; }

        [Required]
        public string Race { get; set; }

    }
}
