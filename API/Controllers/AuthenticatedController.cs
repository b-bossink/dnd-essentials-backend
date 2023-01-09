using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Service.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public abstract class AuthenticatedController : ControllerBase
    {
        protected readonly Service.Authentication.AuthenticationService _authenticationService;
        protected AuthenticatedController(IConfiguration config, JwtHandler jwt)
        {
            _authenticationService = new Service.Authentication.AuthenticationService(new Repository.UserRepo(config.GetConnectionString("localhostMSSQL")), jwt);
        }

        protected async Task<string> GetToken()
        {
            return await HttpContext.GetTokenAsync("Bearer", "access_token");
        }
    }
}

