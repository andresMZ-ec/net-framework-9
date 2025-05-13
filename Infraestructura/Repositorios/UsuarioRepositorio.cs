using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Dominio.Interfaces;

namespace Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AplicationDbContext _context;

        public UsuarioRepositorio(AplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosUsuarios()
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .ToListAsync();
        }

        public async Task<Usuario?> ObtenerUsuarioPorID(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Where(u => !u.EsEliminado)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> ObtenerUsuarioPorFiltro(UsuarioFiltro filtro)
        {
            var query = _context.Usuarios.AsQueryable();
            query.Where(u => !u.EsEliminado);            

            if (string.IsNullOrEmpty(filtro.nombreUsuario))
                query.Where(u => u.NombreUsuario == filtro.nombreUsuario);

            if (string.IsNullOrEmpty(filtro.nombreUsuario))
                query.Where(u => u.Correo == filtro.correoElectronico);

            if (string.IsNullOrEmpty(filtro.numCedula))
                query.Where(u => u.Nui == filtro.numCedula);

            query = query.Include(u => u.Rol);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GuardarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.GuardarCambiosAsync();
            return usuario;
                
        }

        public async Task<Usuario> ActualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.GuardarCambiosAsync();
            return usuario;
        }

        public async Task EliminarUsuario(int id)
        {            
            await _context.LogicDeleteAsync();
        }
    }
}
