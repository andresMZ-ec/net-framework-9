using Aplicacion.DTOs.Permiso;
using Aplicacion.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class PermisoServicio : IPermisoServicio
    {
        private readonly IPermisoRepositorio _permisoRepositorio;
        private readonly IMapper _mapper;

        public PermisoServicio(IPermisoRepositorio permisoRepositorio, IMapper mapper)
        {
            this._permisoRepositorio = permisoRepositorio;
            this._mapper = mapper;
        }

        public async Task<List<PermisoListaDto>> ListaPermisos(string? identificador)
        {
            var permisos = await _permisoRepositorio.TodosPermisos(identificador);
            return _mapper.Map<List<PermisoListaDto>>(permisos);
        }

        public async Task<PermisoDto> NuevoPermiso(Permiso permiso)
        {
            var existeCodigo = await _permisoRepositorio.TodosPermisos(permiso.Codigo);
            if (existeCodigo.Count() > 0)
            {
                throw new InvalidOperationException("El código del permiso ya existe");
            }

            await _permisoRepositorio.CrearPermiso(permiso);
            return _mapper.Map<PermisoDto>(permiso);
        }

        public async Task<PermisoDto> ActualizarPermiso(int id, Permiso data)
        {
            var permiso = await _permisoRepositorio.ObtenerPermisoPorId(id);
            if (permiso == null)
            {
                throw new KeyNotFoundException("El permiso a actualizar no existe");
            }

            var existeCodigo = await _permisoRepositorio.TodosPermisos(data.Codigo);
            if (existeCodigo.Count() > 0)
            {
                throw new InvalidOperationException("El código del permiso ya existe");
            }

            _mapper.Map(data, permiso);
            await _permisoRepositorio.ActualizarPermiso(permiso);
            return _mapper.Map<PermisoDto>(permiso);
        }

        public async Task EliminarPermiso(int id)
        {
            var permiso = await _permisoRepositorio.ObtenerPermisoPorId(id);
            if(permiso != null)
            {
                throw new KeyNotFoundException("El permiso no existe");
            }
            await _permisoRepositorio.EliminarPermiso();
        }

    }
}
