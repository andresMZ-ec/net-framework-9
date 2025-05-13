using Aplicacion.DTOs.Usuario;
using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Servicios
{
    public class AutenticacionServicio : IAutenticacionServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public AutenticacionServicio(IPasswordHasher<Usuario> passwordHasher, IUsuarioRepositorio usuarioRepositorio)
        {
            _passwordHasher = passwordHasher;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> AutenticarUsuario(UsuarioCredencialesDto credenciales)
        {
            var filtro = new UsuarioFiltro
            {
                nombreUsuario = credenciales.nombreUsuario,
                correoElectronico = credenciales.correoElectronico
            };

            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorFiltro(filtro);

            if(usuario != null)
            {
                var verificarContraseña = BCrypt.Net.BCrypt.Verify(credenciales.contraseña, usuario.Contraseña);
                if(verificarContraseña)
                {
                    return usuario;
                }
            }
            throw new UnauthorizedAccessException("El usuario/correo electronico o contraseña son inválidos");
        }
    }
}
