using Film_api.CQRS.FilmCqrs.Command;
using Film_api.CQRS.FilmCqrs.Querry;
using MediatR;
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
            return View();
        }
        //page that display 1 film
        public async Task<IActionResult> SingleFilm(int id)
        {
            return View();
        }
        //controle the create page b
        public async Task<IActionResult> Create()
        {
           

        }
        //manage the data retrieve in the create page

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateFilmCommand command)
        {


            return View();
        }
        //edit part---------------------------------------------------------------------------
        //j'appel une query pour recuperer les info relative a l'object que je desire modifier
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]

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
