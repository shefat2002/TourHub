var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5013");

var app = builder.Build();

var customers = new[]
{
    new { Id = 1, Name = "Rahim", Email = "rahim@example.com", LoyaltyPoints = 1200 },
    new { Id = 2, Name = "Karim", Email = "karim@example.com", LoyaltyPoints = 850 },
    new { Id = 3, Name = "Fatima", Email = "fatima@example.com", LoyaltyPoints = 300 }
};

app.MapGet("/api/customers", () => customers);

app.MapGet("/api/customers/{id}", (int id) => 
{
    var customer = customers.FirstOrDefault(c => c.Id == id);
    return customer is null ? Results.NotFound() : Results.Ok(customer);
});

app.Run();