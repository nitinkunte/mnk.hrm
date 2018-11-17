using System;
using Microsoft.EntityFrameworkCore;
using MNK.HRM.Security.Entities;

namespace MNK.HRM.Security.Helpers
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

}

