using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MNK.HRM.Web.Models;

namespace MNK.HRM.Web.Pages.Employees
{
    public class _employeeDetailsModel : PageModel
    {



        [HttpGet("{id}")]
        public EmployeeModel GetEmployee(int id)
        {
            EmployeeModel ret = new EmployeeModel();




            return ret;

        }

    }
}
