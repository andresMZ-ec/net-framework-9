
namespace Dominio.Entidades
{
    public class Rol : IAuditoria, IEliminacionLogica
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public bool EsEliminado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<Permiso>? Permisos { get; set; }
    }
}
