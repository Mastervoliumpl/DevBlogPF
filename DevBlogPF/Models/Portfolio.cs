namespace DevBlogPF.Models
{
    public class Portfolio : Post
    {
        public Guid PostID { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public PostType PostType { get; set; } = PostType.Portfolio;

        public Portfolio(string title, string projectName, string description, Author author) : base()
        {
            Title = title;
            Description = description;
            Author = author;
            DateCreated = DateTime.Now;
        }
    }
}
