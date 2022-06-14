using Blog_implementation.Models.ForumModel;
using Blog_implementation.Models.PostModels;
using Microsoft.EntityFrameworkCore;

namespace ForumBackend.Data
{
    public class ForumContext : DbContext, IForumContext
    {

        protected ForumContext(DbContextOptions<ForumContext> options) :
            base(options)
        {
        }
        public DbSet<Forum> Forum { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReplies> Replies { get; set; }
    }
}
