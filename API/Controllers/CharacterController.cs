using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persistency.DAL.Service;
using Persistency.Models;
using Persistency.DAL;
using System.Configuration;
using System.Collections;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IService<Character> _service;

        public CharacterController(IConfiguration config)
        {
            _service = new CharacterService(new DatabaseContext(config.GetConnectionString("localhostMSSQL")));
        }

        // GET: api/character
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _service.ReadAll();
            if (res != null)
            {
                return Ok(res);
            }
            return StatusCode(422, "Couldn't GET Character.");
        }

        // GET api/character/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.Read(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }

        // POST api/character
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Character values)
        {
            int res = await _service.Create(values);
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to POST character.");
            }
            return Ok();
        }

        // PUT api/character
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Character value)
        {
            int res = await _service.Update(value);
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
            int res = await _service.Delete(id);
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to DELETE character.");
            }
            return Ok();
        }
    }
}

