using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MNK.HRM.DTO
{
    [Table("EmployeeDemographic")]
    public class EmployeeDemographic : IEmployee
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        [Required]
        public string Ethnicity { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

    }
}
