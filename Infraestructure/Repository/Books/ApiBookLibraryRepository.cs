using BookRadarApp.Infraestructure.Repository.Interfaces.Books;
using BookRadarApp.Models.DTO;
using System.Net.Http;
using System.Text.Json;
using static BookRadarApp.Models.DTO.OpenLibraryResponse;

namespace BookRadarApp.Infraestructure.Repository.Books
{
    public class ApiBookLibraryRepository : IApiBookLibraryRepository
    {
        private readonly HttpClient _httpClient;
        public ApiBookLibraryRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<LibrosPublicadosDTO>> GetBooksByAuthor(string author)
        {
            var url = $"https://openlibrary.org/search.json?author={author}";
            var json = await _httpClient.GetStringAsync(url);
            var root = JsonSerializer.Deserialize<OpenLibraryResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            var libros = root?.Docs?.Select(doc => new LibrosPublicadosDTO
            {
                Titulo = doc.Title ?? string.Empty,
                Año = doc.First_Publish_Year?.ToString() ?? string.Empty,
                Editorial = doc.Publisher?.FirstOrDefault() ?? string.Empty
            }).ToList() ?? new List<LibrosPublicadosDTO>();
            return libros;
        }
    }
}
