using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs.Permiso;

namespace Aplicacion.DTOs.Rol
{
    public class RolListDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public List<PermisoRolDto>? Permisos { get; set; }
    }
}
