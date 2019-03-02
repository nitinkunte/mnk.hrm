using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MNK.HRM.DTO
{

    [Table("Employee")]
    public class Employee : IEmployee
    {

        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Suffix { get; set; }

        public string EmployeeNo { get; set; }

        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }


        #region relationships

        public ICollection<EmployeeAddress> Addresses { get; set; }

        #endregion relationships
    }
}
