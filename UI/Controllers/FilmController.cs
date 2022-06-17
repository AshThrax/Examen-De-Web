using Film_api.CQRS.FilmCqrs.Command;
using Film_api.CQRS.FilmCqrs.Querry;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class FilmController : ApiController
    {

        private readonly IMediator _mediator;

       
        //display MyMovie List

        public async Task<IActionResult> Index()
        {
            
        }
        //page that display 1 film
        public async Task<IActionResult> SingleFilm(int id)
        {
          
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


         
        }
        //edit part---------------------------------------------------------------------------
        //j'appel une query pour recuperer les info relative a l'object que je desire modifier
        public async Task<IActionResult> Edit(int id)
        {
           
        }

        [HttpPost]

        public async Task<IActionResult> Edit([FromBody] UpdateFilmCommand command, int id)
        {
          
        }
        //
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           
        }
    }
}
