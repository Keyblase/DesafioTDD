using DesafioTDD.Core.Interface;
using DesafioTDD.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Net.Http.Json;
namespace DesafioTDD.Product;

public class StarStoreApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public StarStoreApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Configura os mocks necessários
                var productRepositoryMock = new Mock<IProductRepository>();

                services.AddSingleton(productRepositoryMock.Object);
            });
        });
    }

    [Fact]
    public async Task Post_Product_Returns_OkResult()
    {
        // Arrange
        var client = _factory.CreateClient();

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
        var response = await client.PostAsJsonAsync("/starstore/product", product);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task Get_Products_Returns_OkResult()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/starstore/products");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

}
