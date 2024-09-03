namespace DevBlogPF.Models
{
    public abstract class Post
    {
        public Guid PostID { get; init; } = Guid.NewGuid();
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset DateModified { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public List<Tag> Tags { get; set; } = []; // means the same as new "List<Tag>();"
        public PostType PostType { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();

        public Post(Author author)
        {
            Author = author;
        }
    }

    public enum PostType
    {
        BlogPost,
        Portfolio
    }
}
