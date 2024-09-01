namespace DevBlogPF.Models
{
    public class BlogPost : Post
    {
        public string BodyText { get; set; }
        public Guid PostID { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public PostType PostType { get; set; } = PostType.BlogPost;

        public BlogPost(string title, string content, Author author, string bodyText) : base()
        {
            Title = title;
            Content = content;
            Author = author;
            DateCreated = DateTime.Now;
            BodyText = bodyText;
        }

    }
}
