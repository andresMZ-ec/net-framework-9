using System;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Repositorios
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly AplicationDbContext _context;
        
        public RolRepositorio(AplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Rol>> ObtenerListaRoles(bool? activo, string? nombre)
        {
            var query = _context.Roles.AsQueryable();
            query = query.Include(r => r.Permisos);

            if (activo != null)
            {
                query = query.Where(r => r.Estado == activo);
            }
            if(nombre != null)
            {
                query = query.Where(r => r.Nombre == nombre);
            }

            return await query.ToListAsync();
        }

        public async Task<Rol?> ObtenerRolDetalle(int id)            
        {
            return await _context.Roles
                .Include(r => r.Permisos)
                .Where(r => r.Id == id)
                .Where(r => !r.EsEliminado)
                .FirstOrDefaultAsync();
        }

        public async Task<Rol?> ObtenerRolPorNombre(string nombre)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == nombre);
        }

        public async Task CrearRol(Rol nuevoRol) 
        {
            _context.Add(nuevoRol);
            await _context.GuardarCambiosAsync();
        }

        public async Task ActualizarRol(Rol nuevoRol) 
        {
            _context.Update(nuevoRol);
            await _context.GuardarCambiosAsync();
        }

        public async Task EliminarRol() 
        {
            await _context.LogicDeleteAsync();
        }
    }
}
