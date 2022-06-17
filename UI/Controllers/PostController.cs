using Blog_implementation.Models.PostModels;
using Blog_implementation.Service.ForumService;
using Blog_implementation.Service.PostService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Post;
using WebApplication2.Models;

namespace UI.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postservice;
        private readonly IForumService _forumService;
        public PostController(IPostService postService,IForumService forumService)
        {
            _postservice = postService;
            _forumService = forumService;
        }

        public IActionResult Index(int id)
        {
            var post = _postservice.GetbyId(id);

            var Reply = BuildPostReplies(post.Replies); 

            var model = new PostIndex
            {
                Id = post.Id,
                Title = post.Title,
                PostContent=post.Content,
                UserId=post.User.UserId.ToString(),
                UserName=post.User.Name,
                Created=post.Created,           
                Replies=Reply
            };
            return View(model);
        }
        [Authorize]
        public IActionResult Create(int Forumid)
        {
            //note id :forum id
            var formu = _forumService.GetbyId(Forumid);
            var model = new NewPost 
            {
                Forumname=formu.Title,
                Forumid=formu.Id,
                UserName=User.Identity.Name//a couplé avec auth0
            };
            return View (model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(NewPost model)
        {
            var Userid =User.Claims.FirstOrDefault(c => c.Type == "User")?.Value;
            UserProfile user = this.User;
            var post = BuildModel(model,User);
        }


        private IEnumerable<PostReply> BuildPostReplies(IEnumerable<PostReplies> replies)
        {
            return replies.Select(P => new PostReply
            {
                Id = P.Id,
                UserId = P.User.UserId,
                UserName=P.User.Name,
                Created=P.CreateTime,
                ReplyContent=P.Content
                
            });
        }
    }
}
