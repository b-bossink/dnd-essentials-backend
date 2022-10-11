﻿using System;
using System.Collections.Generic;

namespace Persistency.Models
{
    public class Character : DatabaseEntity
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
    }
}
