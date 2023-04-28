using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OptoCoderEcommerceApi.Data.Context;
using OptoCoderEcommerceApi.Repository.Ecommerce;
using OptoCoderEcommerceApi.Service;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var origins = configuration["origins"].Split(';').ToArray();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins(origins);
    }));
builder.Services.AddDbContext<OptocoderEcommerceContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("OptocoderEcommerceContext"));
});
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
