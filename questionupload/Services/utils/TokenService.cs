using Microsoft.IdentityModel.Tokens;
using questionupload.Data.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace questionupload.Services.utils
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user, string[] roles, string[] permissions)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            });

            // Add roles and permissions as claims
            foreach (var role in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            foreach (var permission in permissions)
            {
                claims.AddClaim(new Claim("Permission", permission));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public interface ITokenService
    {
        string GenerateJwtToken(User user, string[] roles, string[] permissions);
    }
}
