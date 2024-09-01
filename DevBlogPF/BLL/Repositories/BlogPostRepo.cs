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
        private readonly IPostRepo _postRepo;

        public BlogPostRepo(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public void CreateBlogPost(Author author, string title, string bodyText)
        {
            // Create a new BlogPost
            BlogPost blogPost = new BlogPost(title, author, bodyText);
            _postRepo.AddPost(blogPost);
        }

        public void UpdateBlogPost()
        {

        }

        public void DeleteBlogPost()
        {

        }

        public void ReturnBlogPosts(BlogPost bPost)
        {
        }
    }
}
