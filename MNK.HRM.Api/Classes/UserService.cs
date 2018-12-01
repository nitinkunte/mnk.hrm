using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MNK.HRM.Api.Data;
using MNK.HRM.Api.Models;
using MNK.HRM.Api.Utils;

namespace MNK.HRM.Api.Classes
{
    public interface IUserService
    {
        Task<ApplicationUser> AuthenticateAsync(string userEmail, string password);
        //IEnumerable<ApplicationUser> GetAll();
        //ApplicationUser GetById(int id);
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetByUserNameAsync(string userName);
        void UpdateAsync(ApplicationUser user, string password = null);
        //void Delete(int id);
    }


    public class UserService : IUserService
    {
        private IdentityContext _context;
        private UserManager<ApplicationUser> _userManager = null;
        private SignInManager<ApplicationUser> _signInManager = null;
        private readonly AppSettings _appSettings;

        public UserService(IdentityContext identityContext, 
                           UserManager<ApplicationUser> userManager, 
                           SignInManager<ApplicationUser> signInManager,
                           IOptions<AppSettings> appSettings)
        {
            _context = identityContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        #region Token Management

        #endregion

        #region User Management

        public async Task<ApplicationUser> AuthenticateAsync(string userEmail, string password)
        {
            ApplicationUser ret = null;
            ApplicationUser user = await _userManager.FindByEmailAsync(userEmail);
 
            if (null != user)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (result.Succeeded)
                {
                    var jwtTokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id)
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                    user.Token = jwtTokenHandler.WriteToken(token);
                    ret = user;
                }
            }

            return ret;
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            ApplicationUser ret = null;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                ret = user;
            }
            return ret;
        }

        public async void UpdateAsync(ApplicationUser user, string password = null)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task<ApplicationUser> GetByUserNameAsync(string userId)
        {
            ApplicationUser ret = await _userManager.FindByIdAsync(userId);
            bool userActive = await _signInManager.CanSignInAsync(ret);
            if (!userActive) ret = null;

            return ret;
        }

        #endregion

        #region SignIn and SignOut
        //public async Task<string> SignIn(string email, string password)
        //{
        //    string ret = string.Empty;
        //    try
        //    {
        //        var user = await _userManager.FindByEmailAsync(email);
        //        if (null != user)
        //        {
        //            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        //            if (result.Succeeded)
        //            {
        //                result.ToString();
        //            }
        //            else
        //            {
        //                ret = result.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return ret;
        //}

        //public async Task<string> SignOut(string email, string password)
        //{
        //    string ret = string.Empty;
        //    try
        //    {
        //        await _signInManager.SignOutAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return ret;
        //}
        #endregion

    }
}
