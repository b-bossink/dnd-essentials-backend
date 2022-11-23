using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Service
{
    public class CharacterService : CRUDService<Character>
    {
        public CharacterService(ICRUDRepo<Character> repo) : base(repo) { }
    }
}

