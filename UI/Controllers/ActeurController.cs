using Microsoft.AspNetCore.Mvc;
using UI.Client;
using UI.Models;

namespace UI.Controllers
{
    public class ActeurController : Controller
    {
        private readonly IActeurClient acteurClient;
        public IActionResult Index()
        {
            var task = acteurClient.GetallAsync();
            return View();
        }
        public IActionResult AddActeur()
        {

            return View();
        }
        public IActionResult AddActeur([FromBody] ActeurViewModel model, int filmid)
        {
            acteurClient.PostAsync(model);

            return RedirectToAction("Index", "Film");
        }

        public IActionResult Delete([FromBody] int id) 
        {
            acteurClient.DeleteAsync( id);

            return RedirectToAction("Index", "Film");
        }
    }

 }

