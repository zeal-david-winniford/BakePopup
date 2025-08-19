using BakePopup.Application.Behaviors;
using BakePopup.Application.Interfaces;
using BakePopup.Application.Queries;
using BakePopup.Application.Queries.Products;
using BakePopup.Application.Services;
using BakePopup.Data;
using BakePopup.Data.Queries.Products;
using BakePopup.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BakePopupContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(QueryBase).Assembly))
    .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IGetProductsDataQuery, GetProductsDataQuery>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
