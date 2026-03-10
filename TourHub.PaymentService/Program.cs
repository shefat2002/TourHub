var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5014");

var app = builder.Build();

var payments = new[]
{
    new { PaymentId = "TXN-1001", BookingId = 101, Amount = 15000, Status = "Completed" },
    new { PaymentId = "TXN-1002", BookingId = 102, Amount = 20000, Status = "Pending" }
};

app.MapGet("/api/payments", () => payments);

app.MapGet("/api/payments/{id}", (string id) => 
{
    var payment = payments.FirstOrDefault(p => p.PaymentId == id);
    return payment is null ? Results.NotFound() : Results.Ok(payment);
});

app.Run();