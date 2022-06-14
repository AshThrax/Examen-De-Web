using Blog_implementation.Models.ForumModel;

namespace Blog_implementation.Models.PostModels
{
    public class PostList
    {
        public int Id { get; set; }
        public string TitlePost { get; set; }
        public string UserName { get; set; }
        public DateTime DatedPosted { get; set; }
        public ForumsList Forum { get; set;  }
        public int ReplyCount { get; set; }
    }
}
