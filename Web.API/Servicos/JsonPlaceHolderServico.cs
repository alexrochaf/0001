using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Web.API.Helpers;
using Web.API.Models.Db;
using Web.API.Servicos.Interfaces;

namespace Web.API.Servicos
{
    public class JsonPlaceHolderServico : IJsonPlaceHolderServico
    {
        private const string Uri = "https://jsonplaceholder.typicode.com";

        public async Task<Cliente> ObterDadosPorEmail(string email)
        {
            var resultado = await HttpHelper.ExecuteRequestAsync(Uri, $"users?email={email}", Method.GET);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var list =  JsonSerializer.Deserialize<List<Cliente>>(resultado.Content, options);

            return list.First();
        }
    }
}
