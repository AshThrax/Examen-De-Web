using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActeurController : ApiController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
