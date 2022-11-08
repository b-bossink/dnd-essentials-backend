using System;
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

        public AuthenticationController(IConfiguration config)
        {
            _service = new AuthenticationService(new Repository.AuthenticationRepo(config.GetConnectionString("localhostMSSQL")));
        }

        // POST api/authentication/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel value)
        {
            User user = ViewModelMapper.Map<User>(value);
            var res = await _service.Register(user);
            Debug.WriteLine(res);
            return Ok();
        }

        // POST api/authentication/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string usernameOrEmail, string password)
        {
            if (await _service.Exists(usernameOrEmail, password))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

