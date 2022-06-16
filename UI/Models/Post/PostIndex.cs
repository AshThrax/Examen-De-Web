namespace UI.Models.Post
{
    public class PostIndex
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public DateTime? Created { get; set; }
        public string PostContent { get; set; }

        public IEnumerable<PostReply> Replies { get; set; }
    }
}
