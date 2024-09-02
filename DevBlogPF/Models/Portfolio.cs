namespace DevBlogPF.Models
{
    public class Portfolio : Post
    {
        public string Description { get; set; }

        public Portfolio(string title, string projectName, string description, Author author) : base(author)
        {
            Title = title;
            Description = description;
            PostType = PostType.Portfolio;
        }
    }
}
