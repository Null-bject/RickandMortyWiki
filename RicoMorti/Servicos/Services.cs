using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using RicoMorti.API;
using RicoMorti.Entidades;

namespace RicoMorti.Servicos
{
    class Services
    {
        private HttpClient? httpClient;

        public async Task<Info> GetServices()
        {
            httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(PathAPI.GetPath);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Re. API: " + content);

                    Info? service = JsonConvert.DeserializeObject<Info>(content);
                    return service ?? new Info();
                }
                else
                {
                    string ERRO = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("ERRO DETECTADO A FETCH API!" + ERRO);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }

            return new Info();
        }
    } 
}

