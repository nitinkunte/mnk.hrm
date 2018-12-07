using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MNK.HRM.Web.DTO;
using Microsoft.Extensions.Logging;


namespace MNK.HRM.Web.Data
{
    public class HRMContext : DbContext
    {
        public HRMContext(DbContextOptions<HRMContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAdresses { get; set; }
        public DbSet<EmployeeDemographic> EmployeeDemographics { get; set; }
        public DbSet<EmployeeImmigration> EmployeeImmigrations { get; set; }
        public DbSet<EmployeeJobDetail> EmployeeJobDetails { get; set; }

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
                new LoggerFactory(new[] {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Address);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.JobDetail);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Demographic);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.JobDetail);

            modelBuilder.Entity<EmployeeAddress>()
                .HasKey(x => x.Id);
                

            //.HasForeignKey<EmployeeAddress>("AddressId");

            base.OnModelCreating(modelBuilder);
        }




        /*
           public async Task<int> SaveEmployee(Employee employee)
           {
               int ret = 0;
               try
               {
                   if (null != employee)
                   {
                       if (employee.Id > 0) //update employee
                       {
                           //check on address
                           if (null != employee.Address)
                           {

                           }


                       }
                       else //insert employee
                       {
                           this.Employees.Add(employee);
                           ret = await this.SaveChangesAsync();
                       }
                   }
               }
               catch (Exception ex)
               {
                   ret = ex.HResult;
               }

               return ret;
           }




           private async Task<int> SaveJobDetails(EmployeeJobDetail input)
           {
               int ret = 0;
               try
               {
                   if (null != input)
                   {
                       var addr = await this.EmployeeJobDetails.FirstOrDefaultAsync(x => x.Id == input.Id);
                       if (null != addr) //update address
                       {
                           addr = input;
                       }
                       else //insert address
                       {
                           this.EmployeeJobDetails.Add(input);
                       }
                       ret = await this.SaveChangesAsync();
                   }
               }
               catch (Exception ex)
               {
                   ret = ex.HResult;
               }

               return ret;
           }
           */
    }
}
