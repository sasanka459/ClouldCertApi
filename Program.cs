using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using qansapi.Controllers;
using qansapi.Models;

var builder = WebApplication.CreateBuilder(args);

//Add Authication to service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAd");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SqldbQansDevCetralind001Context>(Option =>
 Option.UseSqlServer(builder.Configuration.GetConnectionString("connectionsString")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


 app.UseSwagger();
 app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
