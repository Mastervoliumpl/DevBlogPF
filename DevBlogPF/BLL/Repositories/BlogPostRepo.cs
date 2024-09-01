using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlogPF.BLL.Interfaces;
using DevBlogPF.Models;

namespace DevBlogPF.BLL.Repositories
{
    public class BlogPostRepo : IBlogPostRepo
    {
        public object PostID { get; set; }

        public void CreateBlogPost(Author author, string content, string title, string bodyText)
        {
            // Create a new instance of the BlogPost class
            BlogPost blogPost = new BlogPost(title, content, author, bodyText);
            
            //Console.WriteLine("Enter the title of the blog post:");
            //string title = Console.ReadLine();

            //Console.WriteLine("Enter the content of the blog post:");
            //string content = Console.ReadLine();

            //Console.WriteLine("Enter the author's first name:");
            //string firstName = Console.ReadLine();

            //Console.WriteLine("Enter the author's last name:");
            //string lastName = Console.ReadLine();
            
            // Create the author object

            //Console.WriteLine("Enter the body text of the blog post:");
            //string bodyText = Console.ReadLine();


            // Save the blog post to the database or perform any other necessary operations
            // You can add your code here

            //Console.WriteLine("Blog post created successfully!");
        }

        public void UpdateBlogPost()
        {

        }

        public void DeleteBlogPost()
        {

        }

        public void ReturnBlogPosts(BlogPost bPost)
        {
            foreach (bPost in post)
        }
    }
}
