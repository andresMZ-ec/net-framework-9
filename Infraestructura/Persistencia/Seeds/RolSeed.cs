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
    public class RolSeed : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            var fechaActual = DateTime.UtcNow;

            builder.HasData(
                new Rol
                {
                    Id = 1,
                    Nombre = "Desarrollador",
                    Descripcion = "Acceso completo a opciones de administrador y sistema de cotización",
                    Estado = true,
                    EsEliminado = false,
                    FechaCreacion = fechaActual,
                    FechaModificacion = fechaActual
                },
                new Rol
                {
                    Id = 2,
                    Nombre = "Administrador",
                    Descripcion = "Acceso completo al sistema administrativo y opciones de usuarios",
                    Estado = true,
                    EsEliminado = false,
                    FechaCreacion = fechaActual,
                    FechaModificacion = fechaActual
                },
                new Rol
                {
                    Id = 3,
                    Nombre = "Moderador",
                    Descripcion = "Visualizacion de usuarios",
                    Estado = true,
                    EsEliminado = false,
                    FechaCreacion = fechaActual,
                    FechaModificacion = fechaActual
                }
            );
        }
    }
}
