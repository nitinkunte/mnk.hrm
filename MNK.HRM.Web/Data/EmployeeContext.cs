using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MNK.HRM.DTO;
using Microsoft.Extensions.Logging;

namespace MNK.HRM.Web.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<HRMContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAdresses { get; set; }
        public DbSet<EmployeeDemographic> EmployeeDemographics { get; set; }
        public DbSet<EmployeeImmigration> EmployeeImmigrations { get; set; }
        public DbSet<EmployeeJobDetail> EmployeeJobDetails { get; set; }


        public static readonly LoggerFactory _myLoggerFactory =
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
                    .HasMany(x => x.Addresses)
                    .WithOne(x => x.Employee)
                    .HasForeignKey(x => x.EmployeeId);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(x => x.JobDetail);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(x => x.Demographic);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(x => x.JobDetail);

            //modelBuilder.Entity<EmployeeAddress>()
                //.HasKey(x => x.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
