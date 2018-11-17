using System;
using DataTables;


namespace MNK.HRM.Api.Models
{
    public class EmployeeDataTableModel : EditorModel
    {
        public class Employees : EditorModel
        {
            
          //  public int EmpId { get; set; }


            public string Prefix { get; set; }


            public string FirstName { get; set; }


            public string LastName { get; set; }


            public string MiddleName { get; set; }


            public string Suffix { get; set; }

            public string EmployeeId { get; set; }

            //public DateTime DateOfBirth { get; set; }
            public string DateOfBirth { get; set; }

            public int EmployeeAddressId { get; set; }

            public int EmployeeJobDetailId  { get; set; }

            public int EmployeeImmigrationId  { get; set; }

            public int EmployeeDemographicId  { get; set; }
        }


        public class EmployeeAddress : EditorModel
        {

            public int EmployeeAddressId { get; set; }

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

        public class EmployeeDemographic : EditorModel
        {
            public int EmployeeDemographicId { get; set; }

            public string Gender { get; set; }

            public string MaritalStatus { get; set; }

            public string Ethnicity { get; set; }


            public string Race { get; set; }
        }

        public class EmployeeImmigration : EditorModel
        {
            public int EmployeeImmigrationId { get; set; }

            public string WorkAuthorizationType { get; set; }

//            public DateTime? DateOfExpiry { get; set; }
            public string DateOfExpiry { get; set; }

            public string JobTitle { get; set; }

        }

        public class EmployeeJobDetail : EditorModel
        {

            public int EmployeeJobDetailId { get; set; }

            public string DateStarted { get; set; }

            public string DateTerminated { get; set; }
            //public DateTime DateStarted { get; set; }

            //public DateTime? DateTerminated { get; set; }

            public decimal PayRate { get; set; }

            public string PayRateType { get; set; }

            public bool IsEligibleForVacation { get; set; }

            public string JobType { get; set; }

            public string JobTitle { get; set; }

        }
    }
}
