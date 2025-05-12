using Aplicacion.DTOs.Rol;
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IRolServicio
    {
        Task<List<RolListDto>> ListaRoles(bool? activo, string? nombre);
        Task<RolDetalleDto> DetalleRol(int id);
        Task<RolDetalleDto> NuevoRol(Rol nuevoRol);
        Task<RolDetalleDto> ActualizarRol(int id, Rol nuevoRol);
        Task<bool> CambiarEstadoRol(int id, bool estado);
        Task EliminarRol(int id);
    }
}
