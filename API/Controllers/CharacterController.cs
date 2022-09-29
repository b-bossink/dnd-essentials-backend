using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Persistency.DAL;
using Persistency.DAL.Manager;
using Persistency.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private IDatabaseManager<Character> manager = new CharacterManager(new DatabaseContext());

        // GET: api/character
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return manager.ReadAll();
        }

        // GET api/character/{id}
        [HttpGet("{id}")]
        public Character Get(int id)
        {
            return manager.Read(id);
        }

        // POST api/character
        [HttpPost]
        public void Post([FromBody] Character values)
        {
            manager.Create(values);
        }

        // PUT api/character
        [HttpPut()]
        public void Put([FromBody] Character value)
        {
            manager.Update(value);
        }

        // DELETE api/character
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}

