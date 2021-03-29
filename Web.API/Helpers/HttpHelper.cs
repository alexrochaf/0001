using RestSharp;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.API.Helpers
{
    public static class HttpHelper
    {
        public static async Task<IRestResponse> ExecuteRequestAsync(string uri, string rota, object body = null, Dictionary<string, string> headers = null, Method method = Method.GET)
        {
            if (!uri.EndsWith("/"))
                uri += "/";
            if (rota.StartsWith("/"))
                rota = rota.Remove(0, 1);

            var request = new RestRequest(rota, method) { RequestFormat = DataFormat.Json };

            Headers(headers, request);

            Body(body, request);

            var cliente = new RestClient(uri);

            return await cliente.ExecuteAsync(request);
        }

        private static void Headers(Dictionary<string, string> headers, RestRequest request)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
        }

        private static void Body(object body, RestRequest request)
        {
            if (body != null) request.AddJsonBody(JsonSerializer.Serialize(body));
        }

    }
}
