using CodeCadetsAPI.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CodeCadetsAPI
{
    public class JWTSetup
    {
        private readonly IConfigurationSection jwtSettings;

        public JWTSetup(IConfigurationSection jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }
        public JwtSecurityToken CreateToken(User user)
        {
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claim,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials
             );
        }

        public ClaimsPrincipal? GetClaims(string tokenString)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                return handler.ValidateToken(

                    tokenString,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    },
                    out SecurityToken validatedToken
                    );
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public static string Tokens(JwtSecurityToken securityToken)
        {
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }

    public static class JWTExtension
    {
        public static IServiceCollection AddCodeCadetsJWT(this IServiceCollection services, IConfigurationSection jwtSettings)
        {
            return services.AddSingleton(serv =>
            {
                return new JWTSetup(jwtSettings);
            });
        }
    }
}
