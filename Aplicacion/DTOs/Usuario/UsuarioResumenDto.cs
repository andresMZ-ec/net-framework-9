using Aplicacion.DTOs.Rol;

namespace Aplicacion.DTOs.Usuario
{
    public class UsuarioResumenDto
    {
        public int Id { get; set; }
        public RolDto Rol { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Nui { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
