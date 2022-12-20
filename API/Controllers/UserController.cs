using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Models.ViewModel;
using Newtonsoft.Json.Linq;
using Service;
using Service.Authentication;
using Service.Mapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : AuthorizedController
    {
        private readonly UserService _service;
        private readonly CharacterService _characterService;
        private readonly ICRUDService<Campaign> _campaignService;

        public UserController(IConfiguration config, JwtHandler jwt) : base(config, jwt)
        {
            var con = config.GetConnectionString("localhostMSSQL");
            _service = new UserService(new Repository.UserRepo(con));
            _characterService = new CharacterService(new Repository.CharacterRepo(con));
            _campaignService = new CampaignService(new Repository.CampaignRepo(con));
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User u = await _service.Get(id);
            if (u == null)
                return NotFound("User not found.");
            return Ok(ViewModelMapper.Map<GETUserViewModel>(u));
        }

        // GET: api/user/{id}/character
        [HttpGet("{id}/character")]
        public async Task<IActionResult> GetCharacters(int id, string token)
        {
            if (!await _authenticationService.UserIsToken(token, id)) {
                return Unauthorized();
            }

            var characters = await _service.GetCharacters(id);
            if (characters == null) return NotFound("User not found");
            return Ok(characters.Select(c => ViewModelMapper.Map<GETCharacterViewModel>(c)));
        }

        // GET: api/user/{id}/campaign
        [HttpGet("{id}/campaign")]
        public async Task<IActionResult> GetCampaigns(int id, string token)
        {
            if (!await _authenticationService.UserIsToken(token, id))
            {
                return Unauthorized();
            }

            var campaigns = await _service.GetCampaigns(id);
            if (campaigns == null) return NotFound();
            return Ok(campaigns.Select(c => ViewModelMapper.Map<GETCampaignViewModel>(c)));
        }
    }
}

