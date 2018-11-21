using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MNK.HRM.Api.Classes;
using MNK.HRM.Api.Models;

namespace MNK.HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private UserManager<ApplicationUser> _userManager = null;
        private SignInManager<ApplicationUser> _signInManager = null;
        private IUserService _userService = null;

        public IdentityController(UserManager<ApplicationUser> userManager, 
                                  SignInManager<ApplicationUser> signInManager,
                                  IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
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
        [AllowAnonymous]
        public async Task<string> SignIn([FromForm]string email, string password)
        {
            string ret = string.Empty;
            try
            {
               
                var user = await _userManager.FindByEmailAsync(email);

                if (null != user)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                    if (result.Succeeded)
                    {
                        result.ToString();
                    }
                    else
                    {
                        ret = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }

        [HttpPost("signIn2")]
        [AllowAnonymous]
        public async Task<JsonResult> SignIn2([FromBody] UserModel userModel)
        {
            ApplicationUser user = null;
            try
            {
                user = await _userService.AuthenticateAsync(userModel.email, userModel.password);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Json(user);
        }


        [HttpPost("signInOld")]
        [AllowAnonymous]
        public async Task<JsonResult> SignInOld([FromBody]string email, string password)
        {
            ApplicationUser user = null;
            try
            {
                user = await _userService.AuthenticateAsync(email, password);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Json(user);
        }

        [HttpGet("test")]
        [Authorize]
        public string Test()
        {
            return "success";
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
