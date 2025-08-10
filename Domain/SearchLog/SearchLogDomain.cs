using BookRadarApp.Domain.Interfaces.SearchLog;
using BookRadarApp.Infraestructure.Repository.Interfaces.Books;
using BookRadarApp.Infraestructure.Repository.Interfaces.SearchLog;
using BookRadarApp.Models.DTO;

namespace BookRadarApp.Domain.SearchLog
{
    public class SearchLogDomain : ISearchLogDomain
    {
        private readonly ISearchLogRepository _repository;
        public SearchLogDomain(ISearchLogRepository repository)
        {
            _repository = repository;
        }

        public Task<List<HistorialBusquedaDTO>> GetAllSearchData()
        {
            try
            {
                var resultado = _repository.GetAllSearchData();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al procesar la solicitud. Por favor, intente más tarde.", ex);
            }
        }
    }
}
