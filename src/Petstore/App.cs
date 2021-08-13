using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Petstore.Core;
using Petstore.Data;

namespace Petstore
{
    public class App
    {
        public async Task Display(IHttpClient httpClient, IWriter writer, IOrderPetsByCategoryName orderPetsByCategoryName)
        {
            var response = await httpClient.GetAsync(Config.URI);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var json = await response.Content.ReadAsStringAsync();
            var pets = JsonSerializer.Deserialize<List<Pet>>(json, options);

            foreach (var pet in orderPetsByCategoryName.OrderByCategoryName(pets))
            {
                writer.Write(pet);
            }
        }
    }
}