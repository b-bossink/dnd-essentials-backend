﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Models.ViewModel;
using Service;
using Service.Authentication;
using Service.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IConfiguration config, JwtHandler jwt)
        {
            _service = new AuthenticationService(new Repository.UserRepo(config.GetConnectionString("localhostMSSQL")), jwt);
        }

        //TODO: deny duplicate email or username
        // POST api/authentication/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel value)
        {
            bool exists = await _service.Exists(value.Username, value.Password) ||
                await _service.Exists(value.Emailaddress, value.Password);
            if (exists) return Ok(false);

            User user = ViewModelMapper.Map<User>(value);
            var res = await _service.Register(user);
            Debug.WriteLine(res);
            return Ok(true);
        }

        // POST api/authentication/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string usernameOrEmail, string password)
        {
            var res = await _service.Login(usernameOrEmail, password);
            return Ok(res);
        }
    }
}

