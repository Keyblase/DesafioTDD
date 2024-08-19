using DesafioTDD.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace DesafioTDD
{
    public class ProductApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddProduct_ShouldReturnOk_WhenProductIsValid()
        {
            // Arrange
            var product = new ProductMoc
            {
                Title = "Blusa do Imperio",
                Price = 7990,
                Zipcode = "78993-000",
                Seller = "João da Silva",
                ThumbnailHd = "https://cdn.awsli.com.br/600x450/21/21351/produto/3853007/f66e8c63ab.jpg",
                Date = "26/11/2015"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/starstore/product", product);

            // Assert
            response.EnsureSuccessStatusCode(); // Verifica se o status de resposta é 2xx
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddProduct_ShouldReturnBadRequest_WhenProductIsNull()
        {
            // Act
            var response = await _client.PostAsJsonAsync("/starstore/product", null as ProductMoc);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}