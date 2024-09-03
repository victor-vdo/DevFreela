using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DevFreela.Infraestructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public string GenerateJwtToken(string email, string role)
        {
            string issuer = _configuration["Jwt:Issuer"] ?? string.Empty;
            string audience = _configuration["Jwt:Audience"] ?? string.Empty;
            string key = _configuration["Jwt:Key"] ?? string.Empty;

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: issuer, 
                audience: audience, 
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials,
                claims: claims
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            string stringToken = handler.WriteToken(token);

            return stringToken;
        }
    }
}
