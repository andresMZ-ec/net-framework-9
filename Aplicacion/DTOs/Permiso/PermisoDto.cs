using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs.Rol;

namespace Aplicacion.DTOs.Permiso
{
    public class PermisoDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public List<RolDto>? Roles { get; set; }
    }
}
