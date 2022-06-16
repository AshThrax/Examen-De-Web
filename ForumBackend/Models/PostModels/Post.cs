using Blog_implementation.Models.ForumModel;

namespace Blog_implementation.Models.PostModels
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public string Userid { get; set; }

        public virtual Forum ForumLink { get; set; }
        public virtual IEnumerable<PostReplies> Replies { get; set; }
    }
}
