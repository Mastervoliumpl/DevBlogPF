namespace DevBlogPF.Models
{
    public class BlogPost : Post
    {
        public string BodyText { get; set; }
        public Guid PostID { get; init; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public PostType PostType { get; set; } = PostType.BlogPost;

        public BlogPost(string title, Author author, string bodyText) : base(author)
        {
            Title = title;
            DateCreated = DateTimeOffset.Now;
            BodyText = bodyText;
        }

    }
}
