using Gerenciador_de_chamados.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gerenciador_de_chamados.Services
{
    public class TokenServices
    {
        public string Generate(UserModel user)
        {
            //cridor de token
            var handler = new JwtSecurityTokenHandler();
            //chave de segurança encriptada para o credential
            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
            //Dados para criar o token
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            //dados do token (expiração,credenciais, etc)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddDays(1),
            };

            //gera o token com as informações do tokenDescriptor
            var token = handler.CreateToken(tokenDescriptor);
  
            //gera uma string do token
            return handler.WriteToken(token);
            
        }

        private static ClaimsIdentity GenerateClaims(UserModel user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            // Converter enum para string antes de criar a claim
            ci.AddClaim(new Claim(ClaimTypes.Role, ((int)user.Role).ToString()));

            return ci;
        }
    }
}
