using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Models.ViewModel
{
    public class CampaignViewModel
    {
        public string Name { get; set; }
        public ICollection<int> CharacterIDs { get; set; }
    }

    public class GETCampaignViewModel : CampaignViewModel
    {
        public int ID { get; set; }
    }
}

