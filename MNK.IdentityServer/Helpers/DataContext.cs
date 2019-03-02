using Microsoft.EntityFrameworkCore;
using MNK.IdentityServer.Entities;

namespace MNK.IdentityServer.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}