using Aplicacion.DTOs.Permiso;
using Aplicacion.DTOs.Rol;
using Aplicacion.DTOs.Usuario;
using AutoMapper;
using Dominio.Entidades;

namespace API.Configuracion
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Roles
            CreateMap<Rol, RolDto>();
            CreateMap<Rol, RolDetalleDto>();
            CreateMap<Rol, RolListDto>()
                .ForMember(dest => dest.Permisos, opt => opt.MapFrom(src => src.Permisos));
            //Usuarios
            CreateMap<Usuario, UsuarioResumenDto>()
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol));
            CreateMap<Usuario, UsuarioDetalleDto>()
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol));
            //Permisos       
            CreateMap<Permiso, PermisoRolDto>();
            CreateMap<Permiso, PermisoDto>();
            CreateMap<Permiso, PermisoListaDto>();
        }
    }
}
