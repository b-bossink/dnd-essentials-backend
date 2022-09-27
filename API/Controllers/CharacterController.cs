using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignData.Models;
using Microsoft.AspNetCore.Mvc;

namespace CampaignData.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private static IEnumerable<Character> _all = new Character[]
        {
            new Character(1, "My First Character", "Knight", "Monster", 1, 2 ,3 ,4, 5, 6),
            new Character(2, "A Cool Character", "Alchemist", "Human", 6, 5 ,4 ,3, 2, 1)
        };

        // GET: api/character
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return _all;
        }

        // GET api/character/{id}
        [HttpGet("{id}")]
        public Character Get(int id)
        {
            var results = _all.Where(c => c.ID == id).ToList();
            if (results.Count >= 1) {
                return results[0];
            }
            return null;
        }

        // POST api/character
        [HttpPost]
        public void Post([FromBody] Character value)
        {
        }

        // PUT api/character
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Character value)
        {
        }

        // DELETE api/character
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

