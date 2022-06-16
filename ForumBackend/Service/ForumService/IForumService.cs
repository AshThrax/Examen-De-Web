using Blog_implementation.Models.ForumModel;

namespace Blog_implementation.Service.ForumService
{
    public interface IForumService
    {
        Forum GetbyId(int id);

        IEnumerable<Forum> GetAllPost();
        Task<Forum> GetPost(int id);
        void Create(Forum post);
        void DeletePost(int id);
        Task<Forum> Update(int id, Forum post);
    }
}
