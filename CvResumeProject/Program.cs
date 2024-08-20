//using Microsoft.EntityFrameworkCore;
//using MyCv.Application.CQRS.Command;
//using MyCv.Application.Interfaces;
//using MyCv.İnfracture;
//using MyCv.Infrastructure.Repositories;
//using Nest;

//var builder = WebApplication.CreateBuilder(args);



//// Load configuration
//var configuration = builder.Configuration;


////Elastic Search Connection
//var settings = new ConnectionSettings(new Uri("https://localhost:9200"))
//        .CertificateFingerprint("b023df430183cfc41b486348bc64b4198934a513dd4925d7f541898f654dc5ca")
//        .BasicAuthentication("elastic", "XkLCCx1gEGHgUnh7YIZS");
//var client =new ElasticClient(settings);
//builder.Services.AddSingleton<IElasticClient>(client);

//// Add services to the container.
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//// DbContext dependency injection
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));




//// Repository dependency injection
//builder.Services.AddTransient<IClientRepository, ClientRepository>();

//// Add controllers and other services
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build(); // Build method is called only once

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCv.Api v1"));
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCv.Application.CQRS.Command;
using MyCv.Application.Interfaces;
using MyCv.İnfracture;
using MyCv.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Diğer servisleri ekleyin
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
// MediatR ve CQRS işleyicilerini ekleyin
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateClientCommand>());

// DbContext dependency injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repository dependency injection
builder.Services.AddTransient<IClientRepository, ClientRepository>();




// Elastic Search Client

// Add controllers and other services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddElastic(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCv.Api v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


