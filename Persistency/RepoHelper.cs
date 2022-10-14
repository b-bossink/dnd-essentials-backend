using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repository.Connection;

namespace Repository
{
	public static class RepoHelper
	{
		public static async Task<ICollection<T>> PopulateProperties<T>(ICollection<T> collection, DbSet<T> set) where T : ModelBase
		{
			List<T> result = new List<T>();
			foreach (T entity in collection)
			{
				var e = await set.FirstOrDefaultAsync(x => x.ID == entity.ID);
				if (e != null)
                {
					result.Add(e);
                }
			}
			return result;
		}
	}
}

