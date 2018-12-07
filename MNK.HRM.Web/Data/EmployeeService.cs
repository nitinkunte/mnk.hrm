using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MNK.HRM.Web.DTO;

namespace MNK.HRM.Web.Data
{
    public class EmployeeService
    {
        private readonly HRMContext _context;
        public EmployeeService(HRMContext context)
        {
            _context = context;
           
        }

        public async Task<Employee> Get(int id)
        {
            Employee ret = new Employee();
            try
            {
                Employee emp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (null != emp)
                {
                    ret = emp;
                    if (null != ret.AddressId)
                    {
                        ret.Address = await _context.EmployeeAdresses.FirstOrDefaultAsync(x => x.Id == ret.AddressId);
                    }

                    if (null != ret.DemographicId)
                    {
                        ret.Demographic = await _context.EmployeeDemographics.FirstOrDefaultAsync(x => x.Id == ret.DemographicId);
                    }

                    if (null != ret.ImmigrationId)
                    {
                        ret.Immigration = await _context.EmployeeImmigrations.FirstOrDefaultAsync(x => x.Id == ret.ImmigrationId);
                    }

                    if (null != ret.JobDetailId)
                    {
                        ret.JobDetail = await _context.EmployeeJobDetails.FirstOrDefaultAsync(x => x.Id == ret.JobDetailId);
                    }


                }
                ret.Address = ret.Address ?? new EmployeeAddress();
                ret.Demographic = ret.Demographic ?? new EmployeeDemographic();
                ret.Immigration = ret.Immigration ?? new EmployeeImmigration();
                ret.JobDetail = ret.JobDetail ?? new EmployeeJobDetail();
            }
            catch (Exception ex)
            {
                var i = ex.HResult;
            }

            return ret;

        }

      
        public async Task<int> Saveold(Employee employee)
        {
            int ret = 0;
            try
            {
                if (null != employee)
                {
                    Employee emp = await _context.Employees
                                        .Include(x => x.Address)
                                        .Include(x => x.JobDetail)
                                        .Include(x => x.Immigration)
                                        .Include(x => x.Demographic)
                                        .FirstAsync(x => x.Id == employee.Id);

                    if (null == emp)
                    {
                        await _context.AddAsync(employee);
                        await _context.SaveChangesAsync();
                        ret = employee.Id;
                    }
                    else
                    {
                        emp = employee;
                        emp.Address = employee.Address;
                        _context.Update(emp.Address);
                        _context.Update(emp.JobDetail);
                        //_context.Update(emp.Address);
                        //_context.Update(emp.Address);
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                ret = ex.HResult;
            }
            return ret;
        }


        public async Task<int> Save(Employee employee)
        {
            int ret = 0;
            try
            {
                if (null != employee)
                {
 

                    int id = (employee.AddressId.HasValue) ? employee.AddressId.Value : 0;
                    employee.AddressId = await SaveAddress(id, employee.Address);

                    id = (employee.JobDetailId.HasValue) ? employee.JobDetailId.Value : 0;
                    employee.JobDetailId = await SaveJobDetail(id, employee.JobDetail);

                    id = (employee.ImmigrationId.HasValue) ? employee.ImmigrationId.Value : 0;
                    employee.ImmigrationId = await SaveImmigration(id, employee.Immigration);

                    id = (employee.DemographicId.HasValue) ? employee.DemographicId.Value : 0;
                    employee.DemographicId = await SaveDemographic(id, employee.Demographic);


                    //Employee emp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
                    //if (null == emp)
                    //{
                    //    await _context.AddAsync(employee);
                    //}
                    //else
                    //{
                    //    emp = employee;
                    //}

                    if (employee.Id > 0)
                    {
                        _context.Update(employee);
                    }
                    else
                    {
                        _context.Employees.Add(employee);
                    }

                    await _context.SaveChangesAsync();
                    ret = employee.Id;
                }
            }
            catch (Exception ex)
            {
                ret = ex.HResult;
            }
            return ret;
        }


        private async Task<int> SaveAddress(int id, EmployeeAddress input)
        {
            int ret = 0;
            try
            {
                if ((null != input) && (null != input.Address1) && (null != input.City) && (null != input.ZipCode))
                {
                    if (id > 0)
                    {
                        _context.Update(input);
                    }
                    else
                    {
                        _context.EmployeeAdresses.Add(input);
                    }
                    await _context.SaveChangesAsync();
                    ret = input.Id;
                }
                else
                {
                    ret = id;
                }
            }
            catch (Exception ex)
            {
                ret = ex.HResult;
            }

            return ret;
        }

        private async Task<int> SaveJobDetail(int id, EmployeeJobDetail input)
        {
            int ret = 0;
            try
            {
                if ((null != input) && (null != input.PayRateType) && (null != input.JobType))
                {
                    if (id > 0)
                    {
                        _context.Update(input);
                    }
                    else
                    {
                        _context.EmployeeJobDetails.Add(input);
                    }

                    await _context.SaveChangesAsync();
                    ret = input.Id;
                }
                else
                {
                    ret = id;
                }
            }
            catch (Exception ex)
            {
                ret = ex.HResult;
            }

            return ret;
        }

        private async Task<int> SaveImmigration(int id, EmployeeImmigration input)
        {
            int ret = 0;
            try
            {
                if ((null != input) && (null != input.JobTitle) && (null != input.WorkAuthorizationType))
                {
                    if (id > 0)
                    {
                        _context.Update(input);
                    }
                    else
                    {
                        _context.EmployeeImmigrations.Add(input);
                    }
                    await _context.SaveChangesAsync();
                    ret = input.Id;
                }
                else
                {
                    ret = id;
                }
            }
            catch (Exception ex)
            {
                ret = ex.HResult;
            }

            return ret;
        }

        private async Task<int> SaveDemographic(int id, EmployeeDemographic input)
        {
            int ret = 0;
            try
            {
                if ((null != input) && (null != input.Ethnicity) && (null != input.Race))
                {
                    if (id > 0)
                    {
                        _context.Update(input);
                    }
                    else
                    {
                        _context.EmployeeDemographics.Add(input);
                    }
                    await _context.SaveChangesAsync();
                    ret = input.Id;
                }
                else
                {
                    ret = id;
                }
            }
            catch (Exception ex)
            {
                ret = ex.HResult;
            }

            return ret;
        }

    }
}
