using Microsoft.EntityFrameworkCore;
using SmartBiddingBLL.Services;
using SmartBiddingBLL.Services.Interface;
using SmartBiddingDLL;
using SmartBiddingDLL.Data;
using SmartBiddingDLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SmartBiddingAPIV1.Controllers.Api;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
