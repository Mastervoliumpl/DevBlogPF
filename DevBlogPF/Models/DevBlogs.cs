namespace DevBlogPF.Models
{
    public class DevBlogs
    {
        public BlogPost(string title, string content, Author author)
        {
            Title = title;
            Content = content;
            Author = author;
            DateCreated = DateTime.Now;
        }
        public Guid PostID { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public List<BlogPost> Items { get; set; } = new List<BlogPost>();
    }
}
