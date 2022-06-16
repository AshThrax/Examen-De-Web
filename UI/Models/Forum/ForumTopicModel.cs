using Blog_implementation.Models.ForumModel;
using Blog_implementation.Models.PostModels;
using Ui.Models.ForumModel;
using UI.Models.Post;

namespace UI.Models.Forum
{
    public class ForumtopicModel
    {
        public ForumsList Forum { get; set; }
        public IEnumerable<PostList> Posts{ get;set;}
    }
}
