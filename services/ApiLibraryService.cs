
using BookRadarApp.Models.DTO;
using System.Text.Json;
using static BookRadarApp.Models.DTO.OpenLibraryResponse;

namespace BookRadarApp.services
{
    public class ApiLibraryService
    {
        private readonly HttpClient _httpClient;
        private readonly RecordService _recordService;
        public ApiLibraryService(HttpClient httpClient, RecordService recordService)
        {
            _httpClient = httpClient;
            _recordService = recordService;
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

                var libros = root?.Docs?.Select(doc => new LibrosPublicadosDTO
                {
                    Titulo = doc.Title ?? string.Empty,
                    Año = doc.First_Publish_Year?.ToString() ?? string.Empty,
                    Editorial = doc.Publisher?.FirstOrDefault() ?? string.Empty
                }).ToList() ?? new List<LibrosPublicadosDTO>();

                if (libros.Any())
                {
                    var libro = libros.First();

                    await _recordService.SaveSearchData(new HistorialBusquedaDTO
                    {
                        Autor = author,
                        Titulo = libro.Titulo,
                        Editorial = libro.Editorial,
                        AnioPublicacion = int.TryParse(libro.Año, out var año) ? año : null,
                        FechaBusqueda = DateTime.UtcNow
                    });
                }

                return libros;
            }
            catch (Exception ex)
            {
                var mensaje = ex.InnerException?.Message ?? ex.Message;
                Console.WriteLine($"Error al guardar en base de datos: {mensaje}");
                return new List<LibrosPublicadosDTO>();
            }
        }

    }
}
