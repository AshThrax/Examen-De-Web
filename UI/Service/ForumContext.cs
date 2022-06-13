using Blog_implementation.Models;
using Blog_implementation.Models.ForumModel;
using Microsoft.EntityFrameworkCore;

namespace Blog_implementation.Service
{
    public class ForumContext : DbContext,IForumContext
    {
        
        protected ForumContext(DbContextOptions<ForumContext> options):
            base(options)
        {
        }
        public DbSet<Forum> Forum { get; set; }   
        public DbSet<Post> Post { get; set; }
        public DbSet<PostReplies> Replies { get; set; }
    }
}
