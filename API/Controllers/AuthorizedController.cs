using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public abstract class AuthorizedController : ControllerBase
    {
        protected readonly AuthenticationService _authenticationService;
        public AuthorizedController(IConfiguration config, JwtHandler jwt)
        {
            _authenticationService = new AuthenticationService(new Repository.UserRepo(config.GetConnectionString("localhostMSSQL")), jwt);
        }
    }
}

