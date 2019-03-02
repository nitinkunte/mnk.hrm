using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MNK.HRM.DTO
{
    [Table("EmployeeImmigration")]
    public class EmployeeImmigration : IEmployee
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string WorkAuthorizationType { get; set; }

        public DateTime? DateOfExpiry { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

    }
}
