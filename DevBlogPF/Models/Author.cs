namespace DevBlogPF.Models
{
    public class Author
    {
        public Guid AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
    }
}