using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using vuelo.Config;
using vuelo.Models;

namespace vuelo.Services
{
    public class JwtService
    {
        private readonly AppSetting _appSettings;

        public JwtService(IOptions<AppSetting> appSettings) => _appSettings = appSettings.Value;

        public LoginViewModel GenerarToken(UsuarioViewModel userLogin)
        {
            // return null if user not found
            if (userLogin == null) return null!;

            var userResponse = new LoginViewModel() { Usuario = userLogin.Usuario, Rol = userLogin.Rol };

            // authentication successful so generate jwt token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("nombreUsuario", userLogin.Usuario!.ToString()),
                    new Claim(ClaimTypes.Role, userLogin.Rol!),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken(token);
            return userResponse;
        }

        public string? VerificarToken(string token)
        {

            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var nombreUsuario = jwtToken.Claims.First(x => x.Type == "nombreUsuario").Value.ToString();

                // return user id from JWT token if validation successful
                return nombreUsuario;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}