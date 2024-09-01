namespace DevBlogPF.Models
{
    public class Author
    {
        public Guid AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }

        public Author(string firstName, string lastName)
        {
            AuthorID = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateCreated = DateTime.Now;
        }
    }
}