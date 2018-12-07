using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.DTO
{
    [Table("EmployeeImmigration")]
    public class EmployeeImmigration
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

        //public int EmployeeId { get; set; }

        [Required]
        public string WorkAuthorizationType { get; set; }

        public DateTime? DateOfExpiry { get; set; }

        [Required]
        public string JobTitle { get; set; }

    }
}
