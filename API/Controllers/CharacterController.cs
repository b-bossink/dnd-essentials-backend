using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Persistency.DAL.Manager;
using Persistency.Models;
using Persistency.DAL;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly IDatabaseManager<Character> _manager = new CharacterManager(
            new DatabaseContext(@"Server=localhost,1433;Database=DnDEssentials;User Id=SA;Password=db80551Nk!"));

        // GET: api/character
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return _manager.ReadAll();
        }

        // GET api/character/{id}
        [HttpGet("{id}")]
        public Character Get(int id)
        {
            return _manager.Read(id);
        }

        // POST api/character
        [HttpPost]
        public void Post([FromBody] Character values)
        {
            _manager.Create(values);
        }

        // PUT api/character
        [HttpPut()]
        public void Put([FromBody] Character value)
        {
            _manager.Update(value);
        }

        // DELETE api/character
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _manager.Delete(id);
        }
    }
}

