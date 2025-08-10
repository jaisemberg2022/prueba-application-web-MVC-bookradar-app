using BookRadarApp.Application.Interfaces.SearchLog;
using BookRadarApp.Domain.Interfaces.SearchLog;
using BookRadarApp.Models.DTO;

namespace BookRadarApp.Application.SearchLog
{
    public class SearchLogApplication : ISearchLogApplication
    {
        private readonly ISearchLogDomain _domain;
        public SearchLogApplication(ISearchLogDomain domain)
        {
            _domain = domain;
        }
        public Task<List<HistorialBusquedaDTO>> GetAllSearchData()
        {
            return _domain.GetAllSearchData();
        }
    }
}
