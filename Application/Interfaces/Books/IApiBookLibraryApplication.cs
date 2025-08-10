using static BookRadarApp.Models.DTO.OpenLibraryResponse;

namespace BookRadarApp.Application.Interfaces.Books
{
    public interface IApiBookLibraryApplication
    {
        Task<List<LibrosPublicadosDTO>> GetBooksByAuthor(string author);
    }
}
