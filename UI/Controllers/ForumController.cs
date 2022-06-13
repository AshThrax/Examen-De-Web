using Microsoft.AspNetCore.Mvc;
using UI.Models.ForumModel;
using UI.Services;

namespace UI.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAllPost()
                .Select(Forum => new ForumsList
                {
                    Id = Forum.Id,
                    name = Forum.Name,
                    Descritption = Forum.Descritption

                });
            var model = new Forumindex
            {
                Forumlisting = forums
            };
            return View(model);
        }
    }
}
