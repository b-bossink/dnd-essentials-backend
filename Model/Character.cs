﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Character : ModelBase
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

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}

