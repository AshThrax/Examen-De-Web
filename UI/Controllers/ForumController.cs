using Blog_implementation.Models.ForumModel;
using Blog_implementation.Models.PostModels;
using Blog_implementation.Service.ForumService;
using Blog_implementation.Service.PostService;
using Microsoft.AspNetCore.Mvc;
using Ui.Models.ForumModel;
using UI.Models.Forum;
using UI.Models.ForumModel;
using UI.Models.Post;

namespace UI.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IPostService _postService;

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
                    name = Forum.name,
                    Descritption = Forum.Descritption

                });
            var model = new Forumindex
            {
                Forumlisting = forums
            };
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forums = _forumService.GetbyId( id);
            var posts = _postService.GetPostbyForum( id);

            var PostListing = posts.Select(post => new PostList
            {
               Id = post.Id,
               Forum = ForumBuilder(post),
               UserName=post.User.Name,
               TitlePost = post.Title,
               DatedPosted=post.Created,
               ReplyCount=post.Replies.Count()
               
            });
            var model = new ForumtopicModel 
            {
             Posts = PostListing,
             Forum=ForumBuilder(forums)
            };
            return View();
        }

        private ForumsList ForumBuilder(Post post)
        {

            var forum = post.ForumLink;
            return ForumBuilder(forum);
        }
        private ForumsList ForumBuilder(Forum forum)
        {

            return new ForumsList
            {
               id = forum.Id,
               name = forum.Title,
               Description = forum.Description
            };
                   
        }
    }
}
