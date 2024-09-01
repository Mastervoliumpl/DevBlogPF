namespace DevBlogPF.Models
{
    public class Portfolio : Post
    {
        public Guid PostID { get; init; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string Description { get; set; }
        public PostType PostType { get; set; } = PostType.Portfolio;

        public Portfolio(string title, string projectName, string description, Author author) : base(author)
        {
            Title = title;
            Description = description;
            DateCreated = DateTimeOffset.Now;
        }
    }
}
