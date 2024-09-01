using CodeCadetsAPI;
using CodeCadetsAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DashboardDataContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("Data Source=CodeCadets.db"));
    });
var setJwt = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(setJwt["Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = setJwt["Issuer"],
            ValidAudience = setJwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddCodeCadetsJWT(setJwt);

builder.Services.AddAuthorization();
builder.Services.AddControllers(options => { 
    options.RespectBrowserAcceptHeader = true;
    options.EnableEndpointRouting = true;
    options.EnableActionInvokers = true;
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

//app.UseRouting();
app.MapControllers();

app.Run();
