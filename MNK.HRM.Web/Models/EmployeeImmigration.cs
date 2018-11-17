using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class EmployeeImmigration
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Work Authorization")]
        public string WorkAuthorizationType { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> WorkAuthorizationTypes { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [DisplayName("Work Authorization End Date")]
        public DateTime? DateOfExpiry { get; set; }

        [Required]
        [DisplayName("USCIS Job Title")]
        public string JobTitle { get; set; }

    }
}
