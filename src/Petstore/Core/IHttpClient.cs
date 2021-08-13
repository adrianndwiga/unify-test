using System.Net.Http;
using System.Threading.Tasks;

namespace Petstore.Core
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);
    }
}