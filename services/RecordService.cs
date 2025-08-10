using BookRadarApp.Models;
using BookRadarApp.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookRadarApp.services
{
    public class RecordService
    {
        private readonly AppSettingsDbContext _dbContext;
        public RecordService(AppSettingsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveSearchData(HistorialBusquedaDTO data)
        {
            if (!string.IsNullOrWhiteSpace(data.Autor))
            {
                var nuevoRegistro = new HistorialBusquedas
                {
                    Autor = data.Autor.Trim(),
                    FechaConsulta = data.FechaBusqueda,
                    AnioPublicacion = data.AnioPublicacion,
                    Editorial = data.Editorial,
                    Titulo = data.Titulo,
                };
                _dbContext.historialBusquedas.Add(nuevoRegistro);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<HistorialBusquedaDTO>> GetAllSearchData()
        {
            return await _dbContext.historialBusquedas
                .Select(h => new HistorialBusquedaDTO
                {
                    Autor = h.Autor ?? string.Empty,
                    Titulo = h.Titulo ?? string.Empty,
                    Editorial = h.Editorial ?? string.Empty,
                    AnioPublicacion = h.AnioPublicacion,
                    FechaBusqueda = h.FechaConsulta
                })
                .ToListAsync();
        }

    }
}
