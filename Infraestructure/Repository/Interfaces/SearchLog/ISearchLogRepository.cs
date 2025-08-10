using BookRadarApp.Models.DTO;

namespace BookRadarApp.Infraestructure.Repository.Interfaces.SearchLog
{
    public interface ISearchLogRepository
    {
        Task SaveSearchData(HistorialBusquedaDTO data);
        Task<List<HistorialBusquedaDTO>> GetAllSearchData();
    }
}
