using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> ObtenerTodosUsuarios();
        Task<Usuario?> ObtenerUsuarioPorID(int id);
        Task<Usuario?> ObtenerUsuarioPorFiltro(UsuarioFiltro filtro);
        Task<Usuario> GuardarUsuario(Usuario usuario);
        Task<Usuario> ActualizarUsuario(Usuario usuario);
        Task EliminarUsuario(int id);
    }
    
}
