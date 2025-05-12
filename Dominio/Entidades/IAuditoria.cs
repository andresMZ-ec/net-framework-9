
namespace Dominio.Entidades
{
    public interface IAuditoria
    {
        DateTime? FechaCreacion { get; set; }
        DateTime? FechaModificacion { get; set; }

    }
}
