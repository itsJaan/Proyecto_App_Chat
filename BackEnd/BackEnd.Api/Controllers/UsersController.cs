using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(UserModel user)
        {
            var userResult = _userService.addUser(user);
            if (userResult.ResponseCode != ResponseCode.Success)
                return BadRequest(userResult.Error);
            return Ok(userResult.Result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userResult = _userService.getUsers();
            if (userResult.ResponseCode != ResponseCode.Success)
                return BadRequest(userResult.Error);
            return Ok(userResult.Result);
        }


    }
}
