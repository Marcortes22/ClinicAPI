using Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicAPI
{
    public static class AuthHelperscs
    {
        public static string GenerateJWTToken(User user, string role = "USER")
        {
            var claims = new List<Claim> {
        new Claim(ClaimTypes.Name, user.Name),
         new Claim(ClaimTypes.Email, user.Email),
         new Claim(ClaimTypes.Role, role),
         


    };
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes("ClinicInitialJWB_ClinicInitialJWB")
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
