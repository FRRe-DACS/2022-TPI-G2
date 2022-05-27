using AutoMapper;
using FanturApp.Business.Implementations;
using FanturApp.Business.Interfaces;
using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Implementations;
using FanturApp.DataAccess.Interfaces;
using FanturApp.Repository.Dtos;
using FanturApp.Repository.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => 
                   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddTransient<Seed>();



var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfiles());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IPackageBusiness, PackageBusiness>();
builder.Services.AddScoped<IPackageDataAccess, PackageDataAccess>();
builder.Services.AddScoped<IServiceBusiness, ServiceBusiness>();
builder.Services.AddScoped<IServiceDataAccess, ServiceDataAccess>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();
builder.Services.AddScoped<IPassengerBusiness,PassengerBusiness>();
builder.Services.AddScoped<IPassengerDataAccess, PassengerDataAccess>();
builder.Services.AddScoped<IReservationBusiness, ReservationBusiness>();
builder.Services.AddScoped<IReservationDataAccess, ReservationDataAccess>();
builder.Services.AddScoped<IPaymentBusiness, PaymentBusiness>();
builder.Services.AddScoped<IPaymentDataAccess, PaymentDataAccess>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
