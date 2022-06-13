namespace Blog_implementation.Models.ForumModel
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public int Userid { get; set; }

        public virtual Forum ForumLink { get; set; }
        public virtual ICollection<PostReplies> Replies { get; set; }
    }
}
