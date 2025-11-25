using Microsoft.EntityFrameworkCore;
using simpleAzureAPI.Data;
using simpleAzureAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGet("/hello", () =>
{
    return "Hello from Azure!";
});

app.MapGet("/time", () =>
{
    return DateTime.Now.ToString();
});
app.MapGet("/products", async (AppDbContext db) =>
{
    return await db.Products.ToListAsync();
});
app.MapPost("/products", async (AppDbContext db, Product p) =>
{
    db.Products.Add(p);
    await db.SaveChangesAsync();
    return Results.Ok(p);
});

app.Run();

