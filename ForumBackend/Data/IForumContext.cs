using Blog_implementation.Models.ForumModel;
using Blog_implementation.Models.PostModels;
using Microsoft.EntityFrameworkCore;

namespace ForumBackend.Data
{
    public interface IForumContext
    {
        DbSet<Forum> Forum { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostReplies> Replies { get; set; }


    }
}
