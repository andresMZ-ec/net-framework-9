using Aplicacion.DTOs.Permiso;
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IPermisoServicio
    {
        Task<List<PermisoListaDto>> ListaPermisos(string? identificador);
        Task<PermisoDto> NuevoPermiso(Permiso permiso);
        Task<PermisoDto> ActualizarPermiso(int id, Permiso data);
        Task EliminarPermiso(int id);
    }
}
