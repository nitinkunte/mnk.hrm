using System;
using Microsoft.AspNetCore.Identity;

namespace MNK.HRM.Api.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }

        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public string Token { get; set; }
    }
}
