using DesafioTDD.Core.Interface;
using DesafioTDD.Core.Model;
using DesafioTDD.Core.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/starstore/product", (Product product, IProductRepository productRepo) =>
{
    if (product == null)
    {
        return Task.FromResult(Results.BadRequest());
    }

    productRepo.AddProductAsync(product);
    return Task.FromResult(Results.Ok());
});

app.MapGet("/starstore/products", (IProductRepository productRepo) =>
{
    var products = productRepo.GetProductsAsync();
    return Task.FromResult(Results.Ok(products));
});

app.MapPost("/starstore/buy", async (Transaction transaction, IPurchaseRepository purchaseRepo) =>
{
    if (transaction == null || transaction.CreditCard == null)
    {
        return Results.BadRequest();
    }

    await purchaseRepo.AddPurchaseAsync(transaction);
    return Results.Ok();
});

app.MapGet("/starstore/history", async (IPurchaseRepository purchaseRepo) =>
{
    var history = await purchaseRepo.GetAllPurchasesAsync();
    return Results.Ok(history);
});

app.MapGet("/starstore/history/{clientId}", async (Guid clientId, IPurchaseRepository purchaseRepo) =>
{
    var history = await purchaseRepo.GetPurchasesByClientIdAsync(clientId);
    if (history == null || !history.Any())
    {
        return Results.NotFound();
    }

    return Results.Ok(history);
});

app.Run();
