using UI.Models.ForumModel;

namespace UI.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumService _forumService;
        public ForumService(IForumService forumService)
        {
            _forumService = forumService;
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
            return _forumService.Forum.Include(Forum => Forum.Posts);
        }

        public Forum GetbyId(int id)
        {
            return _forumService.Forum.FirsorDefault(x =>x.Id==id);
        }

        public Task<Forum> GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Forum> Update(int id, Forum post)
        {
            throw new NotImplementedException();
        }
    }
}
