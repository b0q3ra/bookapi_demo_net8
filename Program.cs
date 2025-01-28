using BooksApi;
using BooksApi.Models;
using BooksApi.Middleware;
using BooksApi.Services;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Controller Services
builder.Services.AddControllers();

// Add Database Services
builder.Services.AddDbContext<DataContext>(opts => {//BUILD DB SERVICE
    opts.UseSqlite(builder.Configuration["ConnectionStrings:UserConnection"]);
    opts.EnableSensitiveDataLogging();
});

// Add custom DI Services
builder.Services.AddSingleton<BooksApi.Services.ILogger, FileLogger>();

var app = builder.Build();

app.UseMiddleware<RequestLogMiddleware>();
app.MapControllers();
app.MapGet("/", () => "Hello World!");


app.Run();
