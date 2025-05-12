using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs.Usuario;
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<IList<UsuarioResumenDto>> ListaUsuarios();
        Task<UsuarioDetalleDto?> UsuarioPorId(int id);
        Task<Usuario> RegistrarNuevoUsuario(Usuario usuario);
        Task<Usuario> ActualizarUsuario(int id, Usuario datosUsuario);
        Task ActualizarEstadoUsuario(int id, bool estado);
        Task EliminarUsuario(int id);
    }
}
