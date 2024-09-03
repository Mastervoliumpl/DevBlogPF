namespace DevBlogPF.Models
{
    public class Comment
    {
        public Guid CommentID { get; set; } = Guid.NewGuid();
        public string CommentText { get; set; }
        public Author Author { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;

        public Comment(string commentText, Author author)
        {
            CommentText = commentText;
            Author = author;
        }
    }
}
