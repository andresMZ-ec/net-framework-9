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
                    Estado = true,
                    EsEliminado = false,
                    FechaCreacion = fechaActual,
                    FechaModificacion = fechaActual
                }
            );
        }
    }
}
