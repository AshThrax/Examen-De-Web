using Film_api.CQRS.FilmCqrs.Command;
using Film_api.CQRS.FilmCqrs.Querry;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class FilmController : Controller
    {

        private readonly IMediator _mediator;

        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //display MyMovie List

        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllFilmQuery());
            return View(response);
        }
        //page that display 1 film
        public async Task<IActionResult> SingleFilm(int id)
        {
            var response = await _mediator.Send(new GetFilmByIdQuery() { Id = id });
            return View(response);
        }
        //controle the create page b
        public async Task<IActionResult> Create()
        {
            return View();

        }
        //manage the data retrieve in the create page

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateFilmCommand command)
        {


            if (!ModelState.IsValid)
            {
                throw new ArgumentException();
            }
            await _mediator.Send(command);

            return View("Index", "Film");
        }
        //edit part---------------------------------------------------------------------------
        //j'appel une query pour recuperer les info relative a l'object que je desire modifier
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetFilmByIdQuery() { Id = id });
            return View(response);
        }

        [HttpPost]

        public async Task<IActionResult> Edit([FromBody] UpdateFilmCommand command, int id)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { throw new ArgumentException(); }

            await _mediator.Send(command);
            return RedirectToAction("Index", "Film");
        }
        //
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteFilmCommand() { Id = id });

            return RedirectToAction("Index", "Film");
        }
    }
}
