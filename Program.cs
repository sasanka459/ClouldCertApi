using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using qans.BusinessAccessLayer.Abstraction;
using qans.BusinessAccessLayer.Services;
using qans.DataAccessLayer.Abstraction;
using qans.DataAccessLayer.DataService;
using qans.DataAccessLayer.Models;
using qansapi.Controllers;
using qansapi.Models;

var builder = WebApplication.CreateBuilder(args);

//Add Authication to service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAd");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<QansDbContext>(Option =>
 Option.UseSqlServer(builder.Configuration.GetConnectionString("connectionsString")));
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IUserData, UserDataService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding Auth button on swagger

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();


 app.UseSwagger();
 app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
