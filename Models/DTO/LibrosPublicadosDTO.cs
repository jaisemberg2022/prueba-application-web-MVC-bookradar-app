namespace BookRadarApp.Models.DTO;
public class OpenLibraryResponse
{
    public List<OpenLibraryDoc>? Docs
    {
        get; set;
    }

    public class OpenLibraryDoc
    {
        public string? Title { get; set; }
        public int? First_Publish_Year { get; set; }
        public List<string>? Publisher { get; set; }
    }

    public class LibrosPublicadosDTO
    {
        public string Año { get; set; } = string.Empty;
        public string? Autor { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
    }
}