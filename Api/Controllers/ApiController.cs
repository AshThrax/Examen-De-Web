using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
   
        public class ApiController : Controller
        {
            private IMediator _mediator;

            protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        }
    
}
