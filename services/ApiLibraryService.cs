
using BookRadarApp.Models.DTO;
using System.Text.Json;
using static BookRadarApp.Models.DTO.OpenLibraryResponse;

namespace BookRadarApp.services
{
    public class ApiLibraryService
    {
        private readonly HttpClient _httpClient;
        public ApiLibraryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LibrosPublicadosDTO>> GetBooksByAuthor(string author)
        {
            var url = $"https://openlibrary.org/search.json?author={author}";

            try
            {
                var json = await _httpClient.GetStringAsync(url);
                var root = JsonSerializer.Deserialize<OpenLibraryResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return root?.Docs?.Select(doc => new LibrosPublicadosDTO
                {
                    Titulo = doc.Title ?? string.Empty,
                    Año = doc.First_Publish_Year?.ToString() ?? string.Empty,
                    Editorial = doc.Publisher?.FirstOrDefault() ?? string.Empty
                }).ToList() ?? new List<LibrosPublicadosDTO>();
            }
            catch (Exception)
            {
                return new List<LibrosPublicadosDTO>();
            }
        }

    }
}
