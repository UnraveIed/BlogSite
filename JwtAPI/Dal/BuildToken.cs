using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace JwtAPI.Dal
{
    public class BuildToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreprojekampi");
            SymmetricSecurityKey key = new(bytes);
            SigningCredentials credentials = new(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(issuer:"http://localhost", audience:"http://localhost", notBefore:DateTime.Now, expires:DateTime.Now.AddMinutes(1), signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new();


            return handler.WriteToken(token);
        }
    }
}
