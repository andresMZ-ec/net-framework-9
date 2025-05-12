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
    public class PermisoSeed : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.HasData(
                new Permiso
                {
                    Id = 1,
                    Codigo = "admin_users_creating",
                    Nombre = "Crear usuarios"                    
                },
                new Permiso
                {
                    Id = 2,
                    Codigo = "admin_users_updating",
                    Nombre = "Actualizar usuarios",
                },
                new Permiso
                {
                    Id = 3,
                    Codigo = "admin_users_deleting",
                    Nombre = "Eliminar usuarios"
                },
                new Permiso
                {
                    Id = 4,
                    Codigo = "admin_users_list_and_detail",
                    Nombre = "Listar usuarios"
                }
            );
        }
    }
}
