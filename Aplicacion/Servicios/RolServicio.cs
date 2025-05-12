using Aplicacion.DTOs.Rol;
using Aplicacion.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class RolServicio : IRolServicio
    {
        private readonly IRolRepositorio _rolRepositorio;
        private readonly IMapper _mapper;

        public RolServicio(IRolRepositorio rolRepositorio, IMapper mapper)
        {
            this._rolRepositorio = rolRepositorio;            
            this._mapper = mapper;
        }

        public async Task<List<RolListDto>> ListaRoles(bool? activo, string? nombre)
        {
            var roles = await _rolRepositorio.ObtenerListaRoles(activo, nombre);
            return _mapper.Map<List<RolListDto>>(roles);
        }

        public async Task<RolDetalleDto> DetalleRol(int id)
        {
            var rol = await _rolRepositorio.ObtenerRolDetalle(id);
            return _mapper.Map<RolDetalleDto>(rol);
        }

        public async Task<RolDetalleDto> NuevoRol(Rol nuevoRol)
        {
            var existeRol = await _rolRepositorio.ObtenerRolPorNombre(nuevoRol.Nombre);

            if (existeRol != null)
            {
                throw new Exception("El nombre del rol ya existe");
            }
            
            await _rolRepositorio.CrearRol(nuevoRol);
            var rol = _rolRepositorio.ObtenerRolPorNombre(nuevoRol.Nombre);
            return _mapper.Map<RolDetalleDto>(rol);
        }

        public async Task<RolDetalleDto> ActualizarRol(int id, Rol nuevoRol)
        {
            var rol = await _rolRepositorio.ObtenerRolDetalle(id);

            if(rol == null)
            {
                throw new Exception("El rol que intenta modificar no existe");
            }
            if(rol.Nombre != nuevoRol.Nombre)
            {
                var existeNombreRol = await _rolRepositorio.ObtenerRolPorNombre(nuevoRol.Nombre);
                
                if(existeNombreRol != null)
                {
                    throw new Exception("El nombre del rol ya esta en uso");
                }
            }
            nuevoRol.FechaModificacion = DateTime.UtcNow;
            _mapper.Map(nuevoRol, rol);
            await _rolRepositorio.ActualizarRol(rol);
            return _mapper.Map<RolDetalleDto>(rol);
        }

        public async Task<bool> CambiarEstadoRol(int id, bool estado)
        {
            var rol = await _rolRepositorio.ObtenerRolDetalle(id);

            if(rol == null)
            {
                throw new Exception("El rol no esiste");
            }
            //rol.Estado = estado;
            await _rolRepositorio.ActualizarRol(rol);
            return true;            

        }

        public async Task EliminarRol(int id)
        {
            var rol = _rolRepositorio.ObtenerRolDetalle(id);

            if(rol == null)
            {
                throw new Exception("EL rol a eliminar no existe");
            }
            await _rolRepositorio.EliminarRol();
        }

    }
}
