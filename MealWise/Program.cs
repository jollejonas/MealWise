using MealWise.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MealWiseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MealWiseContext")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
