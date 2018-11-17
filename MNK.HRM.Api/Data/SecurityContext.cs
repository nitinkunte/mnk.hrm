using System;
using Microsoft.EntityFrameworkCore;
using MNK.HRM.Security.Helpers;
using MNK.HRM.Security.Entities;

namespace MNK.HRM.Api.Data
{
    public class SecurityContext : MNK.HRM.Security.Helpers.DataContext
    {
        public SecurityContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
