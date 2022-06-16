using Blog_implementation.Models.PostModels;
using ForumBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog_implementation.Service.PostService
{
    public class PostService : IPostService
    {
        private readonly ForumContext _forumContext;

        public PostService(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetbyId(int id)
        {
            return _forumContext.Posts
                .Where(post => post.Id == id)
                .Include(post =>post.User)
                .Include(post =>post.Replies).ThenInclude(reply =>reply.User)
                .Include(post =>post.Title)
                .Include(post =>post.Content)
                .Include(post =>post.ForumLink)
                .Include(post => post.Created).First();
        }

        public IEnumerable<Post> GetPostbyForum(int id)
        {
            return _forumContext.Forum
                .Where(x => x.Id == id)
                .First()
                .Post;
        }

        public Task Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
