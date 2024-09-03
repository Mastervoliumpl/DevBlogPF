namespace DevBlogPF.Models
{
    public class Author
    {
        public Guid AuthorID { get; init; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}