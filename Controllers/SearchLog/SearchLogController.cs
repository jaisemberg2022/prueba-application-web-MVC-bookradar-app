using BookRadarApp.Application.Interfaces.SearchLog;
using Microsoft.AspNetCore.Mvc;

namespace BookRadarApp.Controllers.SearchLog
{
    public class SearchLogController : Controller
    {
        private readonly ISearchLogApplication _application;
        public SearchLogController(ISearchLogApplication application)
        {
            _application = application;
        }

        public async Task<IActionResult> Historial()
        {
            var historial = await _application.GetAllSearchData();
            return View(historial);
        }

    }
}
