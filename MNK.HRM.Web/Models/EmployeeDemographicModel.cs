using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.Models
{
    public class EmployeeDemographicModel
    {

        public EmployeeDemographicModel()
        {
            Ethnicities = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Hispanic", Value = "Hispanic"},
                    new SelectListItem(){ Text = "Not Hispanic.", Value = "Not Hispanic"},
                 };
            Races = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "American Indian", Value = "American Indian"},
                    new SelectListItem(){ Text = "Asian", Value = "Asian"},
                    new SelectListItem(){ Text = "Black", Value = "Black"},
                    new SelectListItem(){ Text = "Other Pacific Islander", Value = "Other Pacific Islander"},
                    new SelectListItem(){ Text = "White", Value = "White"},
                 };

            Genders = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Male", Value = "M"},
                    new SelectListItem(){ Text = "Female", Value = "F"},
                 };

            MaritalStatuses = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Single", Value = "Single"},
                    new SelectListItem(){ Text = "Married", Value = "Married"},
                 };
        }


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
