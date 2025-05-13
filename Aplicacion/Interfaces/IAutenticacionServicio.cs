using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs.Usuario;
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IAutenticacionServicio
    {
        Task<Usuario> AutenticarUsuario(UsuarioCredencialesDto credenciales);
    }
}
