using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MNK.HRM.Web.Data;
using MNK.HRM.Web.Models;

namespace MNK.HRM.Web.Pages.Emp
{

    public class EmployeeDetailsModel : PageModel
    {
        private readonly HRMContext _context;
        public EmployeeDetailsModel(HRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int EmployeeDBId
        {
            get
            {
                int ret = 0;
                if (null != EmployeeDetail)
                {
                    ret = EmployeeDetail.Id;
                }

                return ret;
            }
            set
            {
                if (null != EmployeeDetail)
                {
                    EmployeeDetail.Id = value;
                }
            }
        }

        [BindProperty]
        public Employee EmployeeDetail { get; set; }

        [HttpGet("{Id}")]
        public void OnGet(int Id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == Id);
            if (null == employee)
            {
                employee = new Employee()
                {
                    Address = new EmployeeAddress(),
                    Immigration = new EmployeeImmigration(),
                    JobDetail = new EmployeeJobDetail(),
                    Demographic = new EmployeeDemographic()
                };
            }
            EmployeeDetail = employee;
        }

        public void OnPost()
        {
            Employee employee = EmployeeDetail;
            if (null != employee)
            {
                if (employee.Id > 0)
                {
                    var emp = _context.Employees.FirstOrDefault(x => x.Id == (employee.Id));
                    emp = employee;
                    _context.SaveChanges();
                }
                else
                {
                    _context.Employees.Add(employee);
                    int returnVal = _context.SaveChanges();
                    EmployeeDetail.Id = returnVal;
                }


                //return new OkResult();
            }
            else
            {

               // return new StatusCodeResult(503);
            }


        }

    }
}
