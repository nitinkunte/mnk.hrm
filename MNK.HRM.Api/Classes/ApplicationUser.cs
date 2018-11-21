using System;
using Microsoft.AspNetCore.Identity;

namespace MNK.HRM.Api.Classes
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public string Token { get; set; }
    }
}
