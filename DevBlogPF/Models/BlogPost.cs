namespace DevBlogPF.Models
{
    public class BlogPost : Post
    {
        public string BodyText { get; set; }
        public Guid PostID { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public PostType PostType { get; set; } = PostType.BlogPost;

        public BlogPost(string title, Author author, string bodyText) : base(author)
        {
            Title = title;
            DateCreated = DateTime.Now;
            BodyText = bodyText;
        }

    }
}
