using BookRadarApp.Application.Interfaces.Books;
using BookRadarApp.Domain.Interfaces.Books;
using BookRadarApp.Models.DTO;

namespace BookRadarApp.Application.Books
{
    public class ApiBookLibraryApplication : IApiBookLibraryApplication
    {
        private readonly IApiBookLibraryDomain _domain;

        public ApiBookLibraryApplication(IApiBookLibraryDomain domain)
        {
            _domain = domain;
        }

        public Task<List<OpenLibraryResponse.LibrosPublicadosDTO>> GetBooksByAuthor(string author)
        {
            return _domain.GetBooksByAuthor(author);
        }
    }
}
