using System;
using System.Net.Http;
using Newtonsoft.Json;
using RickAndMortyWiki.models;
using System.Threading.Tasks;


namespace RickAndMortyWiki.services
{
    public class Services
    {
        private readonly HttpClient _httpClient;

        public Services()
        {
            _httpClient = new HttpClient();
        }
        //Character fetch from RestAPI
        public async Task<Response<Character>> GetCharacters(string name = "")
        {
            string url = $"https://rickandmortyapi.com/api/character/?name={name}";
            var resp = await _httpClient.GetAsync(url);
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<Character>>(json)!;
        }
        //Episodes fetch from RestAPI
        public async Task<Response<Episodes>> GetEpisodes(string name = "")
        {
            string url = $"https://rickandmortyapi.com/api/episode/?name={name}";
            var resp = await _httpClient.GetAsync(url);
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<Episodes>>(json)!;
        }
        //Location fetch from RestAPI
        public async Task<Response<Location>> GetLocation(string name = "")
        {
            string url = $"https://rickandmortyapi.com/api/location/?name={name}";
            var resp = await _httpClient.GetAsync(url);
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<Location>>(json)!;
        }


    }
}