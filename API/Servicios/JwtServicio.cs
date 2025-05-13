using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Configuracion;
using Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace API.Servicios
{
    public class TokenServicio
    {
        private readonly JwtConfiguracion _jwtConfiguracion;

        public TokenServicio(JwtConfiguracion configuracion)
        {
            this._jwtConfiguracion = configuracion;            
        }

        public string GenerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguracion.KeySecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfiguracion.ExpirationMinutes),
                Issuer = _jwtConfiguracion.Issuer,
                Audience = _jwtConfiguracion.Audience,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
