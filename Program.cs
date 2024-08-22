using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using qansapi;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using  static qansapi.AuthorizationManager;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Authorization part
var key = "Sridatta12345@@111111111@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@";
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x=>
{
   x.RequireHttpsMetadata = false;
   x.SaveToken= true;
   x.TokenValidationParameters = new TokenValidationParameters
   { 
       ValidateIssuerSigningKey= true,
       IssuerSigningKey =new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
       ValidateIssuer=false,
       ValidateAudience=false

   };
});
builder.Services.AddSingleton<AuthorizationManager>(new AuthorizationManager(key));

var app = builder.Build();


 app.UseSwagger();
 app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
