using System;
using Microsoft.EntityFrameworkCore;
using MNK.HRM.Api.Models;

namespace MNK.HRM.Api.Data
{
    public class HRMContext : DbContext
    {
        public HRMContext(DbContextOptions<HRMContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeDemographic> EmployeeDemographics { get; set; }
        public DbSet<EmployeeImmigration> EmployeeImmigrations { get; set; }
        public DbSet<EmployeeJobDetail> EmployeeJobDetails { get; set; }
    }
}
