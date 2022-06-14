
using Blog_implementation.Models.PostModels;

namespace Blog_implementation.Service.PostService
{
    public interface IPostService
    {
        Post GetbyId(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostbyForum(int id);
        Task Add(Post post);
        Task Delete(int postId);
        Task Update(Post post);
        Task AddReply(Post post);
    }
}
