using Client.Omdb_Client;
using Microsoft.AspNetCore.Mvc;
using Auth0.ManagementApi;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOmdbClient _omdclient;

        public HomeController(ILogger<HomeController> logger, IOmdbClient omdclient)
        {
            _logger = logger;
            _omdclient = omdclient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SearchFilm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Submit(FilmOMdb movie)
        {
            var result = await _omdclient.GetAsync(movie.Title);
            return View("SearchFilm", result);

        }

    }
}