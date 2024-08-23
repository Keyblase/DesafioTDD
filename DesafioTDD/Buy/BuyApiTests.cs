using DesafioTDD.Core.Interface;
using DesafioTDD.Core.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Net.Http.Json;
namespace DesafioTDD.Buy;

public class BuyApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BuyApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var purchaseRepositoryMock = new Mock<IPurchaseRepository>();
                services.AddSingleton(purchaseRepositoryMock.Object);
            });
        });
    }

    [Fact]
    public async Task Post_Buy_Returns_OkResult()
    {
        // Arrange
        var client = _factory.CreateClient();

        var transaction = new Transaction
        {
            ClientId = Guid.NewGuid(),
            ClientName = "Luke Skywalker",
            TotalToPay = 7990,
            CreditCard = new CreditCard
            {
                CardNumber = "1234123412341234",
                CardHolderName = "Luke Skywalker",
                Value = 7990,
                CVV = 789,
                ExpDate = "12/24"
            }
        };

        // Act
        var response = await client.PostAsJsonAsync("/starstore/buy", transaction);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
