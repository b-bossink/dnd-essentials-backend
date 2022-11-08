using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public ICollection<int> CampaignIDs { get; set; }
    }

    public class GETCharacterViewModel : CharacterViewModel
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
    }
}

