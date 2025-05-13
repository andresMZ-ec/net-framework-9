using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Seeds
{
    public class UsuarioSeed : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            var fechaActual = DateTime.UtcNow;

            builder.HasData(
                new Usuario
                {
                    Id = 1,
                    RolId = 1,
                    NombreUsuario = "desarrollador",
                    Nombres = "Desarrollador",
                    Apellidos = "del Sistema",
                    Nui = "9999999999",
                    Correo = "desarrollo@prueba.com",
                    Contraseña = "$2a$12$cUEoxoHu/nXc3ePvRYLQyu7Hj2rrmJq4bdBuZrP56ib7XkKcJ0FGO", //dev12345
                    Estado = true,
                    EsEliminado = false,
                    FechaCreacion = fechaActual,
                    FechaModificacion = fechaActual
                },
                new Usuario
                {
                    Id = 2,
                    RolId = 2,
                    NombreUsuario = "system_admin",
                    Nombres = "Desarrollador",
                    Apellidos = "del Sistema",
                    Nui = "9999999998",
                    Correo = "admin@prueba.com",
                    Contraseña = "$2a$12$/mvFBFCNHt4Ty0pm6GNixuSaouVc8yTfk7JS9l0ZgPszw/SD38zlW",  //admin12345
                    Estado = true,
                    EsEliminado = false,
                    FechaCreacion = fechaActual,
                    FechaModificacion = fechaActual
                },
                new Usuario
                {
                    Id = 3,
                    RolId = 3,
                    NombreUsuario = "system_mod",
                    Nombres = "Moderador",
                    Apellidos = "del Sistema",
                    Nui = "9999999997",
                    Correo = "mod@prueba.com",
                    Contraseña = "$2a$12$WOqfxi5WpLbVITeq/m0AWuKtDIXeDhoA8pcqw9YYaI63xCJlKbs3q",    //mod12345
                    Estado = true,
                    EsEliminado = false,
                    FechaCreacion = fechaActual,
                    FechaModificacion = fechaActual
                }
            );
        }
    }
}
