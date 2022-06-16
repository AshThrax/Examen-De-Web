using Blog_implementation.Models.ForumModel;
using Ui.Models.ForumModel;

namespace UI.Models.Post
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
