using static BookRadarApp.Models.DTO.OpenLibraryResponse;

namespace BookRadarApp.Domain.Interfaces.Books
{
    public interface IApiBookLibraryDomain
    {
        Task<List<LibrosPublicadosDTO>> GetBooksByAuthor(string author);
    }
}
