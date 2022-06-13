using Microsoft.EntityFrameworkCore;
using UI.Models.ForumModel;

namespace UI.Services
{
    public interface IForumContext
    {
        DbSet<Forum> Forum { get; set; }
        DbSet<Post> Post { get; set; }
        DbSet<PostReplies> Replies { get; set; }

       
    }
}
