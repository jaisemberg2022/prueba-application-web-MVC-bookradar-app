using BookRadarApp.services;
using Microsoft.AspNetCore.Mvc;

namespace BookRadarApp.Controllers
{
    public class RecordController : Controller
    {
        private readonly RecordService _recordService;
        public RecordController(RecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task<IActionResult> Historial()
        {
            var historial = await _recordService.GetAllSearchData();
            return View(historial);
        }

    }
}
