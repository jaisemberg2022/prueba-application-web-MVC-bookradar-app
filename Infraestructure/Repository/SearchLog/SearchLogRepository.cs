using BookRadarApp.Infraestructure.Repository.Interfaces.SearchLog;
using BookRadarApp.Models;
using BookRadarApp.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookRadarApp.Infraestructure.Repository.SearchLog
{
    public class SearchLogRepository : ISearchLogRepository
    {
        private readonly AppSettingsDbContext _dbContext;
        public SearchLogRepository(AppSettingsDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
