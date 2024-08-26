namespace DevBlogPF.Models
{
    public class DevBlogs
    {
        public List<BlogPost> Items { get; set; } = new List<BlogPost>();

        public void AddBlogPost(BlogPost blogPost)
        {
            Items.Add(blogPost);
        }

        public void EditBlogPost(BlogPost blogPost)
        {
            // Implementation for editing a blog post
        }

        public void DeleteBlogPost(BlogPost blogPost)
        {
            Items.Remove(blogPost);
        }
    }
}
