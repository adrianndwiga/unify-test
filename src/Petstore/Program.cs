using System.Threading.Tasks;
using Petstore.Core;
using Petstore.Data;

namespace Petstore
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var app = new App();

            await app.Display(
                    new RealHttpClient(),
                    new RealWriter(),
                    new OrderPetsByCategoryNameDesc()
                );
        }
    }
}
