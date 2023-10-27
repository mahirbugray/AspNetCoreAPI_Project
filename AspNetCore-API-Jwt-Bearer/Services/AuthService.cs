using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCore_API_Jwt_Bearer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  string GenereteToken()
        {
            var jwtDefaults = _configuration.GetSection("JwtDefaults");  //appsetting deki jwt verilerini almak için
            var secretKey = jwtDefaults["secretKey"]; //içinden secretKey i almak için

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,"Admin"),   //talepte bulunan kullanıcının hangi rollere sahip olduğu bilgisi alınır admin yerine eklenerek liste oluşturulur
                new Claim(ClaimTypes.Role,"Manager")  
            };

            JwtSecurityToken token = new JwtSecurityToken(issuer: jwtDefaults["ValidIssur"], audience: jwtDefaults["ValidAudience"],claims:claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtDefaults["expires"])), signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();  //token üreten
            return  handler.WriteToken(token);

        }
    }
}
