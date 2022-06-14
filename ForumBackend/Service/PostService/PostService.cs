using Blog_implementation.Models.PostModels;
using ForumBackend.Data;

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
            throw new NotImplementedException();
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
