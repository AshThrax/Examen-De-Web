using Microsoft.AspNetCore.Mvc;
using UI.Client;
using UI.Models;

namespace UI.Controllers
{
    public class FilmController :Controller
    {
        private readonly IFilmClient _filmClient;
        public FilmController(IFilmClient filmClient)
        {
            _filmClient = filmClient;
        }
       
        //display MyMovie List

        public async Task<IActionResult> Index()
        {
            var task = _filmClient.GetallAsync();
            return View(task);
        }
        //page that display 1 film
        public async Task<IActionResult> SingleFilm(int id)
        {
            var task = _filmClient.GetallAsync();
            return View();
        }
        //controle the create page b
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        //manage the data retrieve in the create page

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] FilmViewModel film)
        {

            var task = _filmClient.PostAsync(film);
            return RedirectToAction("Index");
        }
        //edit part---------------------------------------------------------------------------
        //j'appel une query pour recuperer les info relative a l'object que je desire modifier
        public async Task<IActionResult> Edit(int id)
        {
           
            return View();
        }

        [HttpPut]

        public async Task<IActionResult> Edit([FromBody] FilmViewModel film, int id)
        {
            _filmClient.PutAsync(film,id);
            return View();
        }
        //
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _filmClient.DeleteAsync(id);
            return View();
        }
    }
}
