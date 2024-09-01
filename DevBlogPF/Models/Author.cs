namespace DevBlogPF.Models
{
    public class Author
    {
        public Guid AuthorID { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Author(string firstName, string lastName)
        {
            AuthorID = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateCreated = DateTimeOffset.Now;
        }
    }
}