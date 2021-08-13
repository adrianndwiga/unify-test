using System.Net.Http;
using System.Threading.Tasks;

namespace Petstore.Core
{
    public class RealHttpClient : IHttpClient
    {
        public readonly HttpClient client = new HttpClient();

        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return client.GetAsync(uri);
        }
    }
}