using Blog_implementation.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_implementation.Service
{
    public interface IForumContext
    {
        DbSet<Forum> Forum { get; set; }
        DbSet<Post> Post { get; set; }
        DbSet<PostReplies> Replies { get; set; }

       
    }
}
