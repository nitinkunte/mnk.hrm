using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MNK.HRM.Web.Data;
using MNK.HRM.Web.Models;
using Newtonsoft.Json;

namespace MNK.HRM.Web.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly HRMContext _context;

        public IndexModel(HRMContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; }

        public async Task OnGet()
        {
            Employees = await _context.Employees.ToListAsync();
        }



        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> OnGetStaffList2()
        {
            var staffs = await _context.Employees.ToListAsync();

            string ret = JsonConvert.SerializeObject(staffs);

            ret = "{\"data\":" + ret + ", \"options\":[], \"files\":[]}";

            return Content(ret, "application/json");

        }
    }
}
