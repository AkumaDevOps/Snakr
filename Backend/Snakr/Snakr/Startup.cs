using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Snakr.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SnakrDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DevConnection"), 
    ServerVersion.Parse("5.7.42-mysql")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Snakr API", Version = "v1" });
});
var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Snakr API v1");
});
app.UseAuthorization();

app.MapControllers();

app.Run();
