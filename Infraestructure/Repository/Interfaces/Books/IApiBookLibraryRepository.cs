using static BookRadarApp.Models.DTO.OpenLibraryResponse;

namespace BookRadarApp.Infraestructure.Repository.Interfaces.Books
{
    public interface IApiBookLibraryRepository
    {
        Task<List<LibrosPublicadosDTO>> GetBooksByAuthor(string author);
    }
}
