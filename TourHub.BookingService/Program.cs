var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5012");

var app = builder.Build();

var bookings = new[]
{
    new { BookingId = 101, TourId = 1, CustomerName = "Alice", Status = "Confirmed" },
    new { BookingId = 102, TourId = 2, CustomerName = "Bob", Status = "Pending" }
};

app.MapGet("/api/bookings", () => bookings);

app.MapGet("/api/bookings/{id}", (int id) => 
{
    var booking = bookings.FirstOrDefault(b => b.BookingId == id);
    return booking is null ? Results.NotFound() : Results.Ok(booking);
});

app.MapPost("/api/bookings", () => 
{
    return Results.Created("/api/bookings/103", new { Message = "Booking successful!" });
});

app.Run();