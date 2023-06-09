﻿using System.Collections.Generic;
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
using DnD_API_Adapter;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CharacterController : AuthenticatedController
    {
        private readonly ICRUDService<Character> _service;
        private readonly DNDClient _dndApiClient;

        public CharacterController(IConfiguration config, JwtHandler jwt) : base(config, jwt)
        {
            _service = new CharacterService(new Repository.CharacterRepo(config.GetConnectionString("localhostMSSQL")));
            _dndApiClient = new DNDClient();
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

        // GET api/character/races
        [HttpGet("races")]
        public async Task<IActionResult> GetAllRaces()
        {
            var res = await _dndApiClient.GetAllOfIndex("races");
            if (res == null || res.Results.Count() < 1)
            {
                return NotFound();
            }

            return Ok(res.Results);
        }

        // GET api/character/races
        [HttpGet("classes")]
        public async Task<IActionResult> GetAllClasses()
        {
            var res = await _dndApiClient.GetAllOfIndex("classes");
            if (res == null || res.Results.Count() < 1)
            {
                return NotFound();
            }

            return Ok(res.Results);
        }

        // POST api/character
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterViewModel value)
        {
            if (!await _authenticationService.UserIsToken(await GetToken(), value.OwnerID))
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
        public async Task<IActionResult> Delete(int id)
        {
            var character = await _service.Get(id);
            if (character == null) return NotFound();
            if (!await _authenticationService.UserIsToken(await GetToken(), character.User.ID))
            {
                return Unauthorized();
            }

            int res = await _service.Delete(id);
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to DELETE character.");
            }
            return Ok();
        }
    }
}

