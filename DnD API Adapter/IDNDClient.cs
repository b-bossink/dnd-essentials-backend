using System;
using System.Net.Http;
using System.Threading.Tasks;
using DnD_API_Adapter.APIModel;

namespace DnD_API_Adapter
{
	public interface IDNDClient
	{
		public Task<APINavigationObject.Collection> GetAllOfIndex(string index);

		public Task<APIRace> GetRace(string index);

	}
}

