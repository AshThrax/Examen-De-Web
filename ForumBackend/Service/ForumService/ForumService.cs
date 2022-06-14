using Blog_implementation.Models.ForumModel;
using ForumBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog_implementation.Service.ForumService
{
    public class ForumService : IForumService
    {
        private readonly ForumContext _forumContext;
      
        public ForumService(ForumContext forumContext)
        {
           _forumContext= forumContext;
        }
    

        public void Create(Forum post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAllPost()
        {
            return _forumContext.Forum
                .Include(Forum => Forum.Posts);
        }

        public Forum GetbyId(int id)
        {
            return _forumContext.Forum
                .Where(x => x.Id == id)
                .Include(f => f.Posts)
                .ThenInclude(p => p.User);
        }

        public Task<Forum> GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Forum> Update(int id, Forum post)
        {
            throw new NotImplementedException();
        }
        /*
        Task<IEnumerable<Forum>> IForumService.GetAllPost()
        {
            return _forumContext.GetAllPost();
        }
        */
    }
}
