using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var aspnetcoreurl = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls(aspnetcoreurl ?? "http://*:8080");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TodoApi DEMO", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger(options =>
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    }));
    app.UseSwaggerUI();
} else
{
    app.UseSwagger(options =>
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    }));
        app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

