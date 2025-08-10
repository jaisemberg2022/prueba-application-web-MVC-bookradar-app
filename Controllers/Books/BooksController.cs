using BookRadarApp.Application.Books;
using BookRadarApp.Application.Interfaces.Books;
using BookRadarApp.Domain.Interfaces.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookRadarApp.Controllers.Books
{
    public class BooksController : Controller
    {
        private readonly IApiBookLibraryApplication _application; 

        public BooksController(IApiBookLibraryApplication application)
        {
            _application = application;
        }
        public IActionResult Buscar()
        {
            return View();
        }


        public async Task<ActionResult> searchBooksByAuthor(string author)
        {
            var libros = await _application.GetBooksByAuthor(author);

            if (libros == null || !libros.Any())
            {
                ViewBag.Mensaje = "No se encontraron resultados. Puede que el autor no tenga libros registrados o que el servicio esté temporalmente fuera de línea.";
            }

            return View("Buscar", libros);
        }
    }
}
