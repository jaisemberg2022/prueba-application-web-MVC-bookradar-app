using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRadarApp.Models
{
    public class HistorialBusquedas
    {
        public int Id { get; set; }

        public string? Autor { get; set; }

        public string? Titulo { get; set; }

        public int? AnioPublicacion { get; set; }

        public string? Editorial { get; set; }

        public DateTime FechaConsulta { get; set; }

    }
}
