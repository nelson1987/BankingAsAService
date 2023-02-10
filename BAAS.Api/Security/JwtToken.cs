using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BAAS.Api.Security
{
    public class JwtToken
    {
        public string Token { get; set; }
        public string Partner { get; set; }
        public DateTime Expiration { get; set; }
    }
    public class JwtTokenHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly JwtHeader _jwtHeader;
        private readonly SigningCredentials _signingCredentials;

        public JwtTokenHandler(string secretKey)
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _jwtHeader = new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256));
        }

        public JwtToken CreateToken(string partner, DateTime expiration)
        {
            var jwtPayload = new JwtPayload
        {
            { "parceiro", partner },
            { "exp", expiration.Second }
        };

            var jwt = new JwtSecurityToken(_jwtHeader, jwtPayload);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JwtToken
            {
                Token = token,
                Partner = partner,
                Expiration = expiration
            };
        }

        public bool ValidateToken(string token, out JwtToken jwtToken)
        {
            jwtToken = null;
            try
            {
                var jwt = _jwtSecurityTokenHandler.ReadJwtToken(token);
                if (jwt.ValidTo < DateTime.UtcNow)
                {
                    return false;
                }

                jwtToken = new JwtToken
                {
                    Token = token,
                    Partner = jwt.Payload["parceiro"]?.ToString(),
                    Expiration = jwt.ValidTo
                };
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
