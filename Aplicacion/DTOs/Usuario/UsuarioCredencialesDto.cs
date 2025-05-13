using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Usuario
{
    public class UsuarioCredencialesDto
    {
        public string? nombreUsuario {  get; set; }
        public string? correoElectronico { get; set; }
        public string contraseña { get; set; }
    }
}
