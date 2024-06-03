using FluentValidation;
using Microsoft.EntityFrameworkCore;
using zad10.Contexts;
using zad10.Endpoints;
using zad10.Interfaces;
using zad10.Services;
using zad10.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IAccountService, AccountServic>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddValidatorsFromAssemblyContaining<AddProductModelValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var endpoints = app.MapGroup("api");
endpoints.RegisterAccountsEndpoints();
endpoints.RegisterProductsEndpoints();



app.UseHttpsRedirection();


app.Run();
