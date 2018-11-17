using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Newtonsoft.Json;
using DataTables;
using MNK.HRM.Api.Data;
using MNK.HRM.Api.Models;
using MNK.HRM.Api.Classes;
using AutoMapper;
using System.Collections.Specialized;
using Microsoft.Extensions.Primitives;
using System.Reflection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MNK.HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly HRMContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(HRMContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("Get")]
        public async Task<string> Get()
        {


            string ret = string.Empty;
            try
            {
                List<Employee> employees = await _context.Employees.ToListAsync();


                ret = GetEmployeeForDataTable(employees);

            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }

        private string GetEmployeeForDataTable(List<Employee> employees)
        {
            string ret = string.Empty;
            Rootobject ro = new Rootobject()
            {
                draw = 1,
                recordsTotal = employees.Count,
                recordsFiltered = employees.Count
            };

            List<EmployeeDatum> employeeDatums = new List<EmployeeDatum>();
            int i = 0;
            EmployeeDatum employeeDatum;
            foreach (var employee in employees)
            {
                i++;

                employeeDatum = new EmployeeDatum();

                employeeDatum = _mapper.Map<EmployeeDatum>(employee);
                employeeDatum.DT_RowId = "row_" + i.ToString();
                employeeDatum.DT_RowData = new DT_Rowdata() { pkey = i };
                employeeDatums.Add(employeeDatum);
            }

            ro.data = employeeDatums.ToArray();

            ret = JsonConvert.SerializeObject(ro);
            return ret;
        }


        [HttpPost("Get")]
        public async Task<string> Post()
        {
            var req = Request;
            DtRequest dtRequest = new DtRequest(Request.Form);
            List<Employee> employees = GetObj<Employee>(dtRequest.Data); 

            if (dtRequest.Action.ToLower() == "create")
            {
                foreach (Employee employee in employees)
                {
                    _context.Add(employee);
                }
                await _context.SaveChangesAsync();
            }
            else if (dtRequest.Action.ToLower() == "edit")
            {
                foreach (Employee employee in employees)
                {
                    if (employee.Id > 0)
                    {
                        _context.Employees.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return GetEmployeeForDataTable(employees); 
        }


#if NETCOREAPP2_1
        /// <summary>
        /// Get the form action. For use with WebAPI's 'FormDataCollection' collection
        /// </summary>
        /// <param name="data">Data sent from the client-side</param>
        /// <returns>Request type</returns>
        //public List<Employee> Process(IEnumerable<KeyValuePair<String, StringValues>> data, out string dtType)
        //{
        //    DtRequest dtRequest = new DtRequest(data);

        //    object obj = GetObj<Employee>(dtRequest.Data);
        //    List<Employee> employees = obj as List<Employee>;
        //    return employees;
        //}
#endif

        public List<T> GetObj<T>(Dictionary<string, object> input)
        {
            List<T> ret ;
            try
            {
                ret = Activator.CreateInstance<List<T>>();

                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();

                foreach (KeyValuePair<string, object> item in input)
                {
                    if (null != item.Value)
                    {
                        Dictionary<string, object> values = item.Value as Dictionary<string, object>;
                        if (null != values)
                        {
                            T obj = Activator.CreateInstance<T>();
                            foreach (KeyValuePair<string, object> objVal in values)
                            {
                                foreach (PropertyInfo prop in properties)
                                {
                                    if (prop.Name == objVal.Key)
                                    {
                                        prop.SetValue(obj, Convert.ChangeType(objVal.Value, prop.PropertyType), null);
                                    }
                                }
                            }
                            ret.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return ret;
        }



        /// <summary>
        /// Process a request from the Editor client-side to get / set data.
        /// For use with MVC's 'Request.Form' collection
        /// </summary>
        /// <param name="data">Data sent from the client-side</param>
        /// <returns>Self for chaining</returns>
        public void Process(NameValueCollection data = null)
        {
            var list = new List<KeyValuePair<string, string>>();

            if (data != null)
            {
                foreach (var key in data.AllKeys)
                {
                    list.Add(new KeyValuePair<string, string>(key, data[key]));
                }
            }



            //return Process(new DtRequest(list));
        }






        [HttpGet("GetNew")]
        [HttpPost]
        public ActionResult GetNew()
        {
            try
            {
                var dbType = "sqlite";
                var connection = _context.Database.GetDbConnection();
                using (var db = new Database(dbType, connection))
                {
                    //db.Debug(true);

                    DtResponse response = new Editor(db, "Employees")
                        .Debug(true)
                        .Model<EmployeeDataTableModel>("Employees")
                        //.Model<EmployeeDataTableModel>("EmployeeAddress")
                        //.Model<EmployeeDataTableModel>("EmployeeJobDetail")
                        //.Model<EmployeeDataTableModel>("EmployeeDemographic")
                        //.Model<EmployeeDataTableModel>("EmployeeImmigration")
                        // .Field(new Field("Employees.Id", "EmployeeffffId"))
                        //.Field(new Field("Employees.Prefix"))
                        //.Field(new Field("Employees.FirstName")
                        //    .Validator(Validation.NotEmpty())
                        //)
                        //.Field(new Field("Employees.MiddleName"))
                        //.Field(new Field("Employees.LastName"))
                        //.Field(new Field("Employees.Suffix"))
                        //.Field(new Field("Employees.EmployeeId")
                        //    .Validator(Validation.Numeric())
                        //    .SetFormatter(Format.IfEmpty(null))
                        //)
                        //.Field(new Field("Employees.DateOfBirth")
                        //    .Validator(Validation.DateFormat(
                        //        Format.DATE_ISO_8601,
                        //        new ValidationOpts { Message = "Please enter a date in the format yyyy-mm-dd" }
                        //    ))
                        //    .GetFormatter(Format.DateSqlToFormat(Format.DATE_ISO_8601))
                        //    .SetFormatter(Format.DateFormatToSql(Format.DATE_ISO_8601))
                        //)
                        //.Field(new Field("Employee.AddressId")
                        //       .Options(new Options()
                        //                .Table("EmployeeAddress")
                        //                .Value("EmployeeAddressId")
                        //                .Label("EAddrId")
                        //               )
                        //      )
                        //.Field(new Field("Employees.JobDetailId")
                        //       .Options(new Options()
                        //                .Table("EmployeeJobDetail")
                        //                .Value("EmployeeJobDetailId")
                        //                .Label("EJobId")
                        //               )
                        //      )
                        //.Field(new Field("Employees.ImmigrationId")
                        //       .Options(new Options()
                        //                .Table("EmployeeImmigration")
                        //                .Value("EmployeeImmigrationId")
                        //                .Label("EImmiId")
                        //               )
                        //      )

                        //.Field(new Field("Employees.DemographicId")
                        //.Options(new Options()
                        //          .Table("EmployeeDemographic")
                        //          .Value("EmployeeDemographicId")
                        //          .Label("EDemoId")
                        //         )
                        //)
                        //.LeftJoin("EmployeeAddress", "Employees.AddressId", "=", "EmployeeAddress.EmployeeAddressId")
                        //.LeftJoin("EmployeeJobDetail", "Employees.JobDetailId", "=", "EmployeeJobDetail.EmployeeJobDetailId")
                        //.LeftJoin("EmployeeImmigration", "Employees.ImmigrationId", "=", "EmployeeImmigration.EmployeeImmigrationId")
                        //.LeftJoin("EmployeeDemographic", "Employees.DemographicId", "=", "EmployeeDemographic.EmployeeDemographicId")

                        .TryCatch(true)

                        .Process(Request)
                        .Data();
                        

                    return Json(response);
                }
            }
            catch (Exception ex)
            {
              //  ex = ex;
                return null;
            }
        }

        private void GetDebug(string [] debugData)
        {
            var y = debugData;
        }

        [HttpGet("Get2")]
        [HttpPost]
        public ActionResult Get222()
        {
            try
            {
                //var dbType = Environment.GetEnvironmentVariable("DBTYPE");
                //var dbConnection = Environment.GetEnvironmentVariable("DBCONNECTION");

                var dbType = "sqlite";
                //var dbConnection = "Data Source=/Users/nitin/Projects-Temp/MNK.HRM/MNK.HRM.Web/MnkHrm.db;Version=3;";
                var connection = _context.Database.GetDbConnection();
                using (var db = new Database(dbType, connection))
                {

                    //DtResponse response = new Editor(db, "EmployeeImmigration")
                        //.Model<EmployeeImmigration>()
                        //.Field(new Field("Id"))
                        //.Field(new Field("WorkAuthorizationType"))
                        //.Field(new Field("DateOfExpiry"))
                        //.Field(new Field("JobTitle"))
                                            //.TryCatch(false)
                                            //.Process(Request)
                                            //.Data();



                    DtResponse response = new Editor(db, "Employees", "Id")
                        .Model<Employee>()
                        //.Model<EmployeeAddress>()
                        //.Model<EmployeeJobDetail>()
                        //.Model<EmployeeDemographic>()
                        //.Model<EmployeeImmigration>()
                        .Debug(true)
                        //.Field(new Field("Employees.Id", "EmployeeffffId"))
                        //.Field(new Field("Employees.Prefix"))
                        //.Field(new Field("Employees.FirstName")
                        //    .Validator(Validation.NotEmpty())
                        //)
                        //.Field(new Field("Employees.MiddleName"))
                        //.Field(new Field("Employees.LastName"))
                        //.Field(new Field("Employees.Suffix"))
                        //.Field(new Field("Employees.EmployeeId")
                        //    .Validator(Validation.Numeric())
                        //    .SetFormatter(Format.IfEmpty(null))
                        //)
                        //.Field(new Field("Employees.DateOfBirth")
                        //    .Validator(Validation.DateFormat(
                        //        Format.DATE_ISO_8601,
                        //        new ValidationOpts { Message = "Please enter a date in the format yyyy-mm-dd" }
                        //    ))
                        //    .GetFormatter(Format.DateSqlToFormat(Format.DATE_ISO_8601))
                        //    .SetFormatter(Format.DateFormatToSql(Format.DATE_ISO_8601))
                        //)
                        //.Field(new Field("Employees.AddressId")
                        //       .Options(new Options()
                        //                .Table("EmployeeAddress")
                        //                .Value("EmployeeAddressId")
                        //                .Label("EAddrId")
                        //               )
                        //      )
                        //.Field(new Field("Employees.JobDetailId")
                        //       .Options(new Options()
                        //                .Table("EmployeeJobDetail")
                        //                .Value("EmployeeJobDetailId")
                        //                .Label("EJobId")
                        //               )
                        //      )
                        //.Field(new Field("Employees.ImmigrationId")
                        //       .Options(new Options()
                        //                .Table("EmployeeImmigration")
                        //                .Value("EmployeeImmigrationId")
                        //                .Label("EImmiId")
                        //               )
                        //      )

                        //.Field(new Field("Employees.DemographicId")
                              //.Options(new Options()
                              //          .Table("EmployeeDemographic")
                              //          .Value("EmployeeDemographicId")
                              //          .Label("EDemoId")
                              //         )
                              //)
                        //.LeftJoin("EmployeeAddress", "Employees.AddressId", "=", "EmployeeAddress.EmployeeAddressId")
                        //.LeftJoin("EmployeeJobDetail", "Employees.JobDetailId", "=", "EmployeeJobDetail.EmployeeJobDetailId")
                        //.LeftJoin("EmployeeImmigration", "Employees.ImmigrationId", "=", "EmployeeImmigration.EmployeeImmigrationId")
                        //.LeftJoin("EmployeeDemographic", "Employees.DemographicId", "=", "EmployeeDemographic.EmployeeDemographicId")

                        .TryCatch(true)
                        .Process(Request)
                        .Data();

                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                ex = ex;
                return null;
            }
        }
    



    //[HttpGet]
        //public async Task<IActionResult> GetOld()
        //{
        //    var staffs = await _context.Employees.ToListAsync();

        //    string ret = JsonConvert.SerializeObject(staffs);

        //    ret = "{\"data\":" + ret + ", \"options\":[], \"files\":[]}";

        //    return Content(ret, "application/json");
        //}
    }
}
