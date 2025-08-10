using BookRadarApp.Domain.Interfaces.Books;
using BookRadarApp.Infraestructure.Repository.Interfaces.Books;
using BookRadarApp.Infraestructure.Repository.Interfaces.SearchLog;
using BookRadarApp.Models.DTO;
using System.Collections.Generic;
using static BookRadarApp.Models.DTO.OpenLibraryResponse;

namespace BookRadarApp.Domain.Books
{
    public class ApiBookLibraryDomain : IApiBookLibraryDomain
    {
        private readonly IApiBookLibraryRepository _repository;
        private readonly ISearchLogRepository _repositorySearchrLog;


        public ApiBookLibraryDomain(IApiBookLibraryRepository repository, ISearchLogRepository repositorySearchrLog)
        {
            _repository = repository;
            _repositorySearchrLog = repositorySearchrLog;
        }

        public async Task<List<LibrosPublicadosDTO>> GetBooksByAuthor(string author)
        {
            try
            {
                List<LibrosPublicadosDTO> Books = await _repository.GetBooksByAuthor(author);
                if (Books.Any())
                {
                    var Book = Books.First();

                    await _repositorySearchrLog.SaveSearchData(new HistorialBusquedaDTO
                    {
                        Autor = author,
                        Titulo = Book.Titulo,
                        Editorial = Book.Editorial,
                        AnioPublicacion = int.TryParse(Book.Año, out var año) ? año : null,
                        FechaBusqueda = DateTime.UtcNow
                    });
                }
                return Books;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al procesar la solicitud. Por favor, intente más tarde.", ex);
            }
        }
    }
}
