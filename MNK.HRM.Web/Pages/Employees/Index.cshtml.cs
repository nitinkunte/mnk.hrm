using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public IndexModel(HRMContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<EmployeeModel> Employees { get; set; }

        public async Task OnGet()
        {
            List<DTO.Employee> employeeDTOs = await _context.Employees.ToListAsync();
            Employees = new List<EmployeeModel>();
            foreach (var emp in employeeDTOs)
            {
                Employees.Add(_mapper.Map<EmployeeModel>(emp));
            }

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
