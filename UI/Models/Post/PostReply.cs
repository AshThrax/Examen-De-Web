namespace UI.Models.Post
{
    public class PostReply
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
      
        public DateTime Created { get; set; }

        public string ReplyContent { get; set; }

        public int PostId { get; set; }
    }
}
