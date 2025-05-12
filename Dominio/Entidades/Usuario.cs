using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Usuario : IEliminacionLogica, IAuditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RolId { get; set; }

        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Nui { get; set; }
        public bool Estado { get; set; }
        public bool EsEliminado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public Rol? Rol { get; set; }
    }
}
