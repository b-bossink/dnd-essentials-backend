using System;
using System.Collections.Generic;

namespace Models
{
	public class Campaign : ModelBase
	{
		public string Name { get; set; }

		public int? UserId { get; set; }
		public virtual User User { get; set; }

		public virtual ICollection<Character> Characters { get; set; }
	}
}

