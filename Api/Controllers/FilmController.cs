using Application.CQRS.FilmCqrs;
using Application.CQRS.FilmCqrs.Querry;
using Film_api.CQRS.FilmCqrs;
using Film_api.CQRS.FilmCqrs.Command;
using Microsoft.AspNetCore.Authorization;
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

            return await Mediator.Send(new GetAllFilmQuery() ); 
        }
        //--------Create-----------------

        [HttpPost]
        [Authorize(Roles = "Admin,Owner,User")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create( CreateFilmCommand command)
        {
            return await Mediator.Send(command);
        }
        //--------update
        [HttpPut]
        [Authorize(Roles = "Admin,Owner")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Update( int id, UpdateFilmCommand command)
        {
            if (id != command.Id)
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
