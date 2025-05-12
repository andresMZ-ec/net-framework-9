
namespace Dominio.Entidades
{
    public interface IEliminacionLogica
    {
        bool EsEliminado { get; set; }
        DateTime? FechaEliminacion { get; set; }
    }
}
