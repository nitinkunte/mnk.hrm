using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MNK.HRM.Api.Classes;


namespace MNK.HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private UserManager<ApplicationUser> _userManager = null;
        private SignInManager<ApplicationUser> _signInManager = null;

        public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("create")]
        public async Task<string> CreateUser([FromForm]string userName, string email, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(
                    new ApplicationUser()
                    {
                        UserName = userName,
                        Email = email
                    }
                    , password
                );
                if (result.Succeeded)
                {
                    //do something
                }
                else
                {
                    //do something
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "true";
        }

        [HttpPost("signIn")]
        public async Task<string> SignIn([FromForm]string userName, string password)
        {
            try
            {

                //var result = await _signInManager
                //if (result.Succeeded)
                //{
                //    //do something
                //}
                //else
                //{
                //    //do something
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "true";
        }


        [HttpGet("get")]
        public async Task<string> Get()
        {
            try
            {
                var result = await _userManager.CreateAsync(
                    new ApplicationUser()
                    {
                        UserName = "ntiin",
                        Email = "n@b.com",
                        UpdateDate = DateTime.UtcNow

                    }
                    , "PX3G,tGqAQibvLmwrTFToGPz"
                );
                if (result.Succeeded)
                {
                    //do something
                }
                else
                {
                    //do something
                }

            }
            catch (Exception ex)
            {

            }
            return "true";
        }


    }
}
