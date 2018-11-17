using System;
using MNK.HRM.Api.Models;
using AutoMapper;

namespace MNK.HRM.Api.Classes
{

    public class Rootobject
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object[] data { get; set; }
    }

    public class EmployeeDatum : Employee
    {
        [IgnoreMap]
        public string DT_RowId { get; set; }
        [IgnoreMap]
        public DT_Rowdata DT_RowData { get; set; }

    }

    public class EmployeeAddressDatum : EmployeeAddress
    {
        public string DT_RowId { get; set; }
        public DT_Rowdata DT_RowData { get; set; }

    }

    public class EmployeeJobDetailDatum : EmployeeJobDetail
    {
        public string DT_RowId { get; set; }
        public DT_Rowdata DT_RowData { get; set; }

    }

    public class EmployeeDemographicDatum : EmployeeDemographic
    {
        public string DT_RowId { get; set; }
        public DT_Rowdata DT_RowData { get; set; }

    }

    public class EmployeeImmigrationDatum : EmployeeImmigration
    {
        public string DT_RowId { get; set; }
        public DT_Rowdata DT_RowData { get; set; }

    }


    public class DT_Rowdata
    {
        public int pkey { get; set; }
    }

    //public interface IDatum
    //{
    //    string DT_RowId { get; set; }
    //    DT_Rowdata DT_RowData { get; set; }
    //}
}
