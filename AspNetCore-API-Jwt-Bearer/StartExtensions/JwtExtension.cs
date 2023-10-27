using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCore_API_Jwt_Bearer.StartExtensions
{
    public static class JwtExtension
    {                                           //program.cs için            appsettings.json için
        public static void AddJwtSettings(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtDefaults = configuration.GetSection("JwtDefaults");  //appsetting deki jwt verilerini almak için
            var secretKey = jwtDefaults["secretKey"]; //içinden secretKey i almak için
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,   //token üret
                    ValidateAudience = true,  //token denetle
                    ValidateLifetime = true,   //token ömür kontrolleri
                    ValidateIssuerSigningKey = true, //bizim verdiğimiz secret keyi kullan

                    ValidIssuer = jwtDefaults["ValidIssur"], //appsetting deki değeri alır
                    ValidAudience = jwtDefaults["ValidAudience"], //appsettingden değeri alır
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), //bizim verdiğimiz keyi encode eder
                    ClockSkew=TimeSpan.Zero //isteyen cihazla aradaki saat farkını sıfırlar
                };
            });
        }
    }
}
