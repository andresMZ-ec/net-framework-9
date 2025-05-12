using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Infraestructura.Persistencia.Seeds;

namespace Infraestructura.Persistencia
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<Permiso>()
                .HasMany(p => p.Roles)
                .WithMany(r => r.Permisos)
                .UsingEntity<PermisosRoles>();

            //Seeds
            modelBuilder.ApplyConfiguration(new PermisoSeed());
            modelBuilder.ApplyConfiguration(new RolSeed());
            modelBuilder.ApplyConfiguration(new PermisoRolSeed());
            modelBuilder.ApplyConfiguration(new UsuarioSeed());


            base.OnModelCreating(modelBuilder);
        }

    }
}
