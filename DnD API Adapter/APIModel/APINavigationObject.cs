using System;
namespace DnD_API_Adapter.APIModel
{
	public class APINavigationObject
	{
        public string Index { get; set; }
        public string Name { get; set; }

        public class Collection
        {
            public APINavigationObject[] Results { get; set; }
        }
    }
}

