using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MNK.HRM.DTO
{
    [Table("EmployeeAddress")]
    public class EmployeeAddress: IEmployee
    {

        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneCell { get; set; }

        public string EmailPersonal { get; set; }

        public string EmailWork { get; set; }

        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
