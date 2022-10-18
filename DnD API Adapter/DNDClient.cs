using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DnD_API_Adapter.APIModel;

namespace DnD_API_Adapter
{
    public class DNDClient : IDNDClient
    {
        private readonly HttpClient _client;

        public DNDClient()
        {
            _client = new HttpClient();

            _client.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<APINavigationObject.Collection> GetAllOfIndex(string index)
        {
            HttpResponseMessage response = await _client.GetAsync(index);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<APINavigationObject.Collection>();
            }
            return null;
        }

        public async Task<APIRace> GetRace(string index)
        {
            HttpResponseMessage response = await _client.GetAsync("races/" + index);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<APIRace>();
            }
            return null;
        }
    }
}

