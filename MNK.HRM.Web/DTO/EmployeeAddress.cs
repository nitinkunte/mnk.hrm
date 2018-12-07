using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MNK.HRM.Web.DTO
{
    [Table("EmployeeAddress")]
    public class EmployeeAddress
    {

        [ForeignKey("Employee")]
        public int Id { get; set; }

        //public int EmployeeId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneCell { get; set; }

        public string EmailPersonal { get; set; }

        public string EmailWork { get; set; }

    }
}
