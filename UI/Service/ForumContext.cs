using Microsoft.EntityFrameworkCore;
using UI.Models.ForumModel;

namespace UI.Services
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
