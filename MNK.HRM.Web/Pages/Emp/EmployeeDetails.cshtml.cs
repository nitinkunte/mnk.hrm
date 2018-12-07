using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MNK.HRM.Web.Data;
using MNK.HRM.Web.DTO;
using MNK.HRM.Web.Models;

namespace MNK.HRM.Web.Pages.Emp
{

    public class EmployeeDetailsModel : PageModel
    {
        private readonly HRMContext _context;
        private readonly IMapper _mapper;

        public EmployeeDetailsModel(HRMContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public int EmployeeDBId
        { get; set;
            //get
            //{
            //    int ret = 0;
            //    if (null != EmployeeDetail)
            //    {
            //        ret = EmployeeDetail.Id;
            //    }

            //    return ret;
            //}
            //set
            //{
            //    if (null != EmployeeDetail)
            //    {
            //        EmployeeDetail.Id = value;
            //    }
            //}
        }

        [BindProperty]
        public EmployeeModel EmployeeDetail { get; set; }

        [HttpGet("{Id}")]
        public async void OnGet(int Id)
        {

            //Employee employeeDto = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
            EmployeeService service = new EmployeeService(_context);
            Employee employeeDto = await service.Get(Id);
            EmployeeModel employee;
            if (null == employeeDto)
            {
                employee = new EmployeeModel();
            }
            else
            {
                employee = _mapper.Map<EmployeeModel>(employeeDto);
            }

            //populate the enumerables & make sure internal classes are initialized
            employee = PopulateEnumAndInternalClasses(employee);

            EmployeeDetail = employee;
            EmployeeDBId = employee.Id;
        }

        public async void OnPost()
        {
            EmployeeModel employee = EmployeeDetail;
            if (null != employee)
            {
                EmployeeService service = new EmployeeService(_context);
                Employee employeeDto = _mapper.Map<Employee>(employee);
                await service.Save(employeeDto);
            }
        }

        [HttpPost]
        public async void Save()
        {
            EmployeeModel employee = EmployeeDetail;
            if (null != employee)
            {
                EmployeeService service = new EmployeeService(_context);
                Employee employeeDto = _mapper.Map<Employee>(employee);
                await service.Save(employeeDto);
            }
        }


        /// <summary>
        /// Populates the enum and internal classes.
        /// </summary>
        /// <returns>The enum and internal classes.</returns>
        /// <param name="employee">Employee.</param>
        private EmployeeModel PopulateEnumAndInternalClasses(EmployeeModel employee)
        {
            if (null != employee)
            {
                employee.Prefixes = new List<SelectListItem>()
                {
//                    new SelectListItem(){ Text = "Please select ...", Value = ""},
                    new SelectListItem(){ Text = "Mr.", Value = "Mr."},
                    new SelectListItem(){ Text = "Ms.", Value = "Ms."},
                    new SelectListItem(){ Text = "Mrs.", Value = "Mrs."},
                    new SelectListItem(){ Text = "Dr.", Value = "Dr."},                
                 };

                employee.Suffixes = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Please select ...", Value = ""},
                    new SelectListItem(){ Text = "Sr.", Value = "Sr."},
                    new SelectListItem(){ Text = "Jr.", Value = "Jr."},
                 };

                if (null == employee.Address)
                {
                    employee.Address = new EmployeeAddressModel();
                }
                if (null == employee.JobDetail)
                {
                    employee.JobDetail = new EmployeeJobDetailModel();
                }
                if (null == employee.Immigration)
                {
                    employee.Immigration = new EmployeeImmigrationModel();
                }
                if (null == employee.Demographic)
                {
                    employee.Demographic = new EmployeeDemographicModel();
                }
            }
            return employee;
        }

    }
}
