using AutoMapper;
using FanturApp.Business.Implementations;
using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Helpers;
using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Implementations;
using FanturApp.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddMvc();

//builder.Services.AddTransient<Seed>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



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
builder.Services.AddScoped<IValidationBusiness, ValidationBusiness>();
builder.Services.AddScoped<ISpamBusiness, SpamBusiness>();
builder.Services.AddScoped<ISpamDataAccess, SpamDataAccess>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//inicializamos la instancia del helper
ValidationApi.InitializeClient();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
