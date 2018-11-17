using System;
using Microsoft.EntityFrameworkCore;
using MNK.HRM.Web.Models;

namespace MNK.HRM.Web.Data
{
    public class HRMContext : DbContext
    {
        public HRMContext(DbContextOptions<HRMContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
