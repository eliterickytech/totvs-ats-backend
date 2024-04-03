using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service
{
    public class TokenApplication : ITokenApplication
    {
        private readonly IConfiguration _configuration;

        public TokenApplication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(CandidateResult candidate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII
                .GetBytes(_configuration.GetSection("SecretJWT").Value);


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, candidate.Name),
                    new Claim(ClaimTypes.Role, candidate.Permission),
                    new Claim(ClaimTypes.Email, candidate.Email),
                    new Claim("Id", candidate.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
