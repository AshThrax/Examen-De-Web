using Film_api.CQRS.ActeurCqrs;
using Film_api.CQRS.ActeurCqrs.Command;
using Film_api.CQRS.ActeurCqrs.Query;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]//send json
    [Route("api/[controller]")]
    [ApiController]
    public class ActeurController : ApiController
    {

        [HttpGet]

        [Authorize(Roles = "Admin,Owner,User,guest")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<ActeurDto>>> Get()
        {

            return await Mediator.Send( new GetAllActeurQuery());
        }
        //--------Create-----------------

        [HttpPost]
        [Authorize(Roles = "Admin,Owner,User")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromForm] CreateActeurCommand command)
        {
            return await Mediator.Send(command);
        }
        //--------update
        [HttpPut]
        [Authorize(Roles = "Admin,Owner")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Update([FromForm] string title, UpdateActeurCommand command)
        {
            if (title != command.Name)
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
        public async Task<ActionResult> Delete(DeleteActeurCommand command)
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
