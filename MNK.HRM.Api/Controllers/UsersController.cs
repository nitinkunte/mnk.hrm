using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


using MNK.HRM.Api.Data;

namespace MNK.HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        //private IUserService _userService;
        //private IMapper _mapper;
        //private readonly AppSettings _appSettings;

        //public UsersController(IUserService userService,
        //                       IMapper mapper,
        //                       IOptions<AppSettings> appSettings)
        //{
        //    _userService = userService;
        //    _mapper = mapper;
        //    _appSettings = appSettings.Value;
        //}

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    var userDtos = _mapper.Map<IList<UserDto>>(users);
        //    return Ok(userDtos);
        //}
    }
}
