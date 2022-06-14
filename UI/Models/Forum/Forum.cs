using System;

namespace Blog_implementation.Models.ForumModel
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Urlimage { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
