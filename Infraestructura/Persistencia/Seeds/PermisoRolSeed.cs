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
    public class PermisoRolSeed : IEntityTypeConfiguration<PermisosRoles>
    {
        public void Configure(EntityTypeBuilder<PermisosRoles> builder)
        {
            builder.HasData(
                new PermisosRoles { PermisoId = 1, RolId = 1 },
                new PermisosRoles { PermisoId = 1, RolId = 2 },
                new PermisosRoles { PermisoId = 2, RolId = 1 },
                new PermisosRoles { PermisoId = 2, RolId = 2 },
                new PermisosRoles { PermisoId = 3, RolId = 1 },
                new PermisosRoles { PermisoId = 3, RolId = 2 },
                new PermisosRoles { PermisoId = 4, RolId = 1 },
                new PermisosRoles { PermisoId = 4, RolId = 2 },
                new PermisosRoles { PermisoId = 4, RolId = 3 }
            );
        }
    }
}
