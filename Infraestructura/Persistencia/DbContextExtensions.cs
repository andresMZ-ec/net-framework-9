using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infraestructura.Persistencia
{
    public static class DbContextExtensions
    {
        private static object ApplyChangesAuditory(object entity, EntityState state)
        {
            if (entity is IAuditoria camposAuditoria)
            {
                var fechaActual = DateTime.UtcNow;

                switch (state)
                {
                    case EntityState.Added:
                        camposAuditoria.FechaCreacion = fechaActual;
                        camposAuditoria.FechaModificacion = fechaActual;
                        break;
                    case EntityState.Modified:
                        camposAuditoria.FechaModificacion = fechaActual;
                        break;
                    default: return entity;
                }
            }

            return entity;
        }

        public static async Task GuardarCambiosAsync(this AplicationDbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                ApplyChangesAuditory(entry.Entity, entry.State);
                //if(entry.Entity is IAuditoria camposAuditoria)
                //{
                //    var fechaActual = DateTime.UtcNow;

                //    switch (entry.State)
                //    {
                //        case EntityState.Added:
                //            camposAuditoria.FechaCreacion = fechaActual;
                //            camposAuditoria.FechaModificacion = fechaActual;
                //            break;
                //        case EntityState.Modified:
                //            camposAuditoria.FechaModificacion = fechaActual;
                //            break;
                //        default: return;
                //    }
                //}
            }

            await context.SaveChangesAsync();
        }
        
        public static async Task LogicDeleteAsync(this AplicationDbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if(entry.Entity is IEliminacionLogica camposEliminacion)
                {
                    camposEliminacion.EsEliminado = true;
                    camposEliminacion.FechaEliminacion = DateTime.UtcNow;
                    entry.State = EntityState.Modified;
                }
            }
            await GuardarCambiosAsync(context);
        }
    }
}
