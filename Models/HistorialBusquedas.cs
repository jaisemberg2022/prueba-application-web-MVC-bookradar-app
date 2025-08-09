using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRadarApp.Models
{
    public class HistorialBusquedas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Autor { get; set; }

        [Required]
        [StringLength(50)]
        public string? Titulo { get; set; }

        [Required]
        public int AnioPublicacion { get; set; }

        [Required]
        [StringLength(50)]
        public string? Editorial { get; set; }

        [Required]
        public DateTime FechaConsulta { get; set; }

    }
}
