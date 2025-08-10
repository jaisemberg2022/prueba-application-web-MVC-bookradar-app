using BookRadarApp.Models.DTO;

namespace BookRadarApp.Application.Interfaces.SearchLog
{
    public interface ISearchLogApplication
    {
        Task<List<HistorialBusquedaDTO>> GetAllSearchData();
    }
}
