using Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace ClinicAPI
{
    public static class AuthHelperscs
    {
        public static string GenerateJWTToken(User user, string role = "USER")
        {
            var claims = new List<Claim> {
                new Claim("Name", user.Name),
                new Claim("Email", user.Email),
                new Claim("Role", role),
                new Claim("Id", user.Id.ToString()),
                new Claim("Phone", user.CellPhone)

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
