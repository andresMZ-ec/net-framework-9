using System.Text;
using Aplicacion.DTOs.Usuario;
using Aplicacion.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dominio.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;
        //private readonly 

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            this._usuarioRepositorio = usuarioRepositorio;
            this._mapper = mapper;
        }

        private bool VerificarDuplicado(Usuario usuario, Usuario? duplicado)
        {
            if (duplicado != null)
            {
                if (duplicado?.NombreUsuario == usuario.NombreUsuario)
                {
                    throw new Exception("Nombre de usuario ya registrado anteriormente");
                }
                if (duplicado?.Correo == usuario.Correo)
                {
                    throw new Exception("Correo electrónico ya registrado anteriormente");
                }
                if (duplicado?.Nui == usuario.Nui)
                {
                    throw new Exception("El número único de identificación ya existe");
                }
            }

            return false;
        }

        public async Task<IList<UsuarioResumenDto>> ListaUsuarios()
        {
            var usuarios = await _usuarioRepositorio.ObtenerTodosUsuarios();
            return _mapper.Map<IList<UsuarioResumenDto>>(usuarios);
        }

        public async Task<UsuarioDetalleDto?> UsuarioPorId(int id)
        {
            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorID(id);
            return _mapper.Map<UsuarioDetalleDto>(usuario);
        }

        public async Task<Usuario> RegistrarNuevoUsuario(Usuario usuario)
        {
            var filtroBusqueda = new UsuarioFiltro
            {
                nombreUsuario = usuario.NombreUsuario,
                correoElectronico = usuario.Correo,
                numCedula = usuario.Nui
            };

            var usuarioDuplicado = await _usuarioRepositorio.ObtenerUsuarioPorFiltro(filtroBusqueda);

            VerificarDuplicado(usuario, usuarioDuplicado);
            var usuarioRegistrado = await _usuarioRepositorio.GuardarUsuario(usuario);
            return usuarioRegistrado;
        }

        public async Task<Usuario> ActualizarUsuario(int id, Usuario datosUsuario)
        {
            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorID(id);
            if(usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var usuarioDuplicado = await _usuarioRepositorio.ObtenerUsuarioPorFiltro(new UsuarioFiltro
            {
                nombreUsuario = datosUsuario.NombreUsuario,
                correoElectronico = datosUsuario.Correo,
                numCedula = datosUsuario.Nui
            });

            if(usuarioDuplicado?.Id != usuario.Id)
            {
                VerificarDuplicado(usuario, usuarioDuplicado);
            }
            _mapper.Map(datosUsuario, usuario);
            return await _usuarioRepositorio.ActualizarUsuario(usuario);
        }

        public async Task ActualizarEstadoUsuario(int id, bool estado)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObtenerUsuarioPorID(id);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado o no existe");
                }

                if (usuario.Estado != estado)
                {
                    usuario.Estado = estado;
                    await _usuarioRepositorio.ActualizarUsuario(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error inesperado al cambiar el estado del usuario");
            }
        }

        public async Task EliminarUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObtenerUsuarioPorID(id);
                if (usuario == null)
                {
                    throw new Exception("El usuario que intenta eliminar no existe");
                }
                await _usuarioRepositorio.EliminarUsuario(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
