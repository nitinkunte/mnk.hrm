using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class EmployeeDemographic
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Genders { get; set; }

        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> MaritalStatuses { get; set; }

        [Required]
        [DisplayName("Ethnicity")]
        public string Ethnicity { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Ethnicities { get; set; }

        [Required]
        [DisplayName("Race")]
        public string Race { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Races { get; set; }

    }
}
