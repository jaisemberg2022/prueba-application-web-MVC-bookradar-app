using BookRadarApp.services;
using Microsoft.AspNetCore.Mvc;

namespace BookRadarApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApiLibraryService _apiLibraryService;

        public BooksController(ApiLibraryService apiLibraryService)
        {
            _apiLibraryService = apiLibraryService;
        }
        public IActionResult Buscar()
        {
            return View(); // Busca Views/Books/Buscar.cshtml
        }


        public async Task<ActionResult> searchBooksByAuthor(string author)
        {
            var libros = await _apiLibraryService.GetBooksByAuthor(author);

            if (libros == null || !libros.Any())
            {
                ViewBag.Mensaje = "No se encontraron resultados. Puede que el autor no tenga libros registrados o que el servicio esté temporalmente fuera de línea.";
            }

            return View("Buscar", libros);
        }
    }
}
