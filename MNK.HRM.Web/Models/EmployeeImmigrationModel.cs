using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class EmployeeImmigrationModel
    {

        public EmployeeImmigrationModel()
        {
            WorkAuthorizationTypes = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Citizen", Value = "Citizen"},
                    new SelectListItem(){ Text = "EAD", Value = "EAD"},
                    new SelectListItem(){ Text = "Green Card", Value = "Green Card"},
                    new SelectListItem(){ Text = "H1B", Value = "H1B"},
                    new SelectListItem(){ Text = "L1", Value = "L1"},
                    new SelectListItem(){ Text = "L2", Value = "L2"},
                 };
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Work Authorization")]
        public string WorkAuthorizationType { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> WorkAuthorizationTypes { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [DisplayName("Work Authorization End Date")]
        public DateTime? DateOfExpiry { get; set; }

        [Required]
        [DisplayName("USCIS Job Title")]
        public string JobTitle { get; set; }

    }
}
