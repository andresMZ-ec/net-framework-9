using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios
{
    public class PermisoRepositorio : IPermisoRepositorio
    {
        private readonly AplicationDbContext _context;

        public PermisoRepositorio(AplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<List<Permiso>> TodosPermisos(string? codigo)
        {
            var query = _context.Permisos.AsQueryable();

            if(!string.IsNullOrEmpty(codigo))
            {
                query = query.Where(p => p.Codigo.Trim() == codigo.Trim());
                
            }
            return await query.ToListAsync();
        }

        public async Task<Permiso?> ObtenerPermisoPorId(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            return permiso;
        }

        public async Task CrearPermiso(Permiso permiso)
        {
            _context.Permisos.Add(permiso);
            await _context.GuardarCambiosAsync();
        }

        public async Task ActualizarPermiso(Permiso permiso)
        {
            _context.Permisos.Update(permiso);
            await _context.GuardarCambiosAsync();
        }

        public async Task EliminarPermiso()
        {
            await _context.LogicDeleteAsync();
        }
    }
}
