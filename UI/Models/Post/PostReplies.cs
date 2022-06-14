using Blog_implementation.Models.ForumModel;

namespace Blog_implementation.Models.PostModels
{
    public class PostReplies
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }


    }
}
