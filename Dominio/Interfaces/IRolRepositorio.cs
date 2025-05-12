using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IRolRepositorio
    {
        Task<IEnumerable<Rol>> ObtenerListaRoles(bool? activo, string? nombre);
        Task<Rol?> ObtenerRolDetalle(int id);
        Task<Rol?> ObtenerRolPorNombre(string nombre);
        Task CrearRol(Rol nuevoRol);
        Task ActualizarRol(Rol nuevoRol);
        Task EliminarRol();

    }
}
