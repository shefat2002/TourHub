var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5011");

var app = builder.Build();

var tours = new[]
{
    new { Id = 1, Name = "Sundarbans Safari", Price = 15000, Duration = "3 Days" },
    new { Id = 2, Name = "Cox's Bazar Beach Resort", Price = 20000, Duration = "4 Days" },
    new { Id = 3, Name = "Sylhet Tea Gardens", Price = 12000, Duration = "2 Days" }
};

app.MapGet("/api/tours", () => tours);

app.MapGet("/api/tours/{id}", (int id) => 
{
    var tour = tours.FirstOrDefault(t => t.Id == id);
    return tour is null ? Results.NotFound() : Results.Ok(tour);
});

app.Run();