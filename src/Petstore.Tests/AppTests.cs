using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Petstore.Core;
using Petstore.Data;

namespace Petstore.Tests
{

    public class AppTests
    {

        private Mock<IHttpClient> httpClientMock;
        private Mock<IWriter> writerMock;
        private IList<Pet> pets;
        private Mock<IOrderPetsByCategoryName> orderPetsByCategoryNameMock;

        [SetUp]
        public void BeforeEachTest()
        {
            httpClientMock = new Mock<IHttpClient>();
            writerMock = new Mock<IWriter>();
            orderPetsByCategoryNameMock = new Mock<IOrderPetsByCategoryName>();
        }

        [Test]
        public async Task Should_Return_Pets_From_Petstore()
        {
            // Given
            var pet = new Pet
            {
                Id = 123,
                Name = "Pet name",
                Category = new Category
                {
                    Id = 1234,
                    Name = "Category name"
                },
                PhotoUrls = new string[] {
                    "some photo urls"
                },
                Tags = new Tag[] {
                    new Tag {
                        Id = 1234566,
                        Name = "tag name"
                    }
                },
                Status = "available"
            };
            var pets = new Pet[] { pet };
            var swaggerResponse = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK, Content = new StringContent(JsonSerializer.Serialize(pets)) };
            httpClientMock.Setup(x => x.GetAsync(Config.URI)).Returns(Task.FromResult(swaggerResponse));
            writerMock.Setup(x => x.Write(pet));
            orderPetsByCategoryNameMock.Setup(x => x.OrderByCategoryName(It.Is<List<Pet>>(y => y[0].Id == pet.Id))).Returns(pets);

            // When
            await new App().Display(httpClientMock.Object, writerMock.Object, orderPetsByCategoryNameMock.Object);

            // Then
            httpClientMock.Verify(x => x.GetAsync(Config.URI));
            writerMock.Verify(x => x.Write(It.Is<Pet>(p => p.Id == pet.Id)));
            orderPetsByCategoryNameMock.Verify(x => x.OrderByCategoryName(It.Is<List<Pet>>(y => y[0].Id == pet.Id)));
        }
    }
}