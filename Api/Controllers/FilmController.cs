using Application.Films.Command;
using Application.Films.Query.GetFilm;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ApiController
    {

        [HttpGet]
      
        [Authorize(Roles ="Admin,Owner,User,guest")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<FilmVm>> Get()
        {

            return await Mediator.Send(new GetFilmQuery()); 
        }
        //--------Create-----------------

        [HttpPost]
        [Authorize(Roles = "Admin,Owner,User")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromForm] CreateFilmCommand command)
        {
            return await Mediator.Send(command);
        }
        //--------update
        [HttpPut]
        [Authorize(Roles = "Admin,Owner")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Update([FromForm] string title, UpdateFilmCommand command)
        {
            if (title != command.Title)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(DeleteFilmCommand command)
        {
            try
            {
                await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unable to Supress");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
