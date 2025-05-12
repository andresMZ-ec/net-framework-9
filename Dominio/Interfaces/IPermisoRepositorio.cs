
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IPermisoRepositorio
    {
        Task<List<Permiso>> TodosPermisos(string? codigo);
        Task<Permiso?> ObtenerPermisoPorId(int id);
        Task CrearPermiso(Permiso permiso);
        Task ActualizarPermiso(Permiso permiso);
        Task EliminarPermiso();
    }
}
