using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System.Configuration;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using Service;
using Models.ViewModel;
using Service.Mapper;
using Microsoft.AspNetCore.Authorization;
using Service.Authentication;

namespace API.Controllers
{
    //TODO: better error handling.
    //TODO: fixed unauthorized msg.
    [Route("api/[controller]")]
    public class CharacterController : AuthorizedController
    {
        private readonly ICRUDService<Character> _service;

        public CharacterController(IConfiguration config, JwtHandler jwt) : base(config, jwt)
        {
            _service = new CharacterService(new Repository.CharacterRepo(config.GetConnectionString("localhostMSSQL")));
        }


        // GET: api/character
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _service.GetAll();
            if (res != null)
            {
                return Ok(res.Select(c => ViewModelMapper.Map<GETCharacterViewModel>(c)));
            }
            return StatusCode(422, "Couldn't GET Character.");
        }

        // GET api/character/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.Get(id);
            if (res != null)
            {
                return Ok(ViewModelMapper.Map<GETCharacterViewModel>(res));
            }
            return NotFound();
        }

        // POST api/character
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterViewModel value, string token)
        {
            if (!await _authenticationService.UserIsToken(token, value.OwnerID))
            {
                return Unauthorized();
            }

            int res = await _service.Create(ViewModelMapper.Map<Character>(value));
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to POST character.");
            }
            return Ok();
        }

        // PUT api/character
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CharacterViewModel value)
        {
            Character character = ViewModelMapper.Map<Character>(value);
            character.ID = id;
            int res = await _service.Update(character);
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to UPDATE character.");
            }
            return Ok();
        }

        // DELETE api/character
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, string token)
        {
            var user = await _authenticationService.GetUser(token);
            var character = await _service.Get(id);
            if (user == null || user.ID != character.User.ID)
                return Unauthorized();


            int res = await _service.Delete(id);
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to DELETE character.");
            }
            return Ok();
        }
    }
}

