using BookRadarApp.Models.DTO;

namespace BookRadarApp.Domain.Interfaces.SearchLog
{
    public interface ISearchLogDomain
    {
        Task<List<HistorialBusquedaDTO>> GetAllSearchData();
    }
}
