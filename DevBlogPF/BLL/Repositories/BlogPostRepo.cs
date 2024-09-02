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

        public void DeleteBlogPost(Guid postID)
        {
            // Find the BlogPost
            BlogPost blogPost = (BlogPost)_postRepo.GetAllPosts().Find(p => p.PostID == postID);

            // Delete the BlogPost
            _postRepo.RemovePost(blogPost);
        }

        public void EditBlogPost(string title, string bodyText, Guid postID)
        {
            // Find the BlogPost
            BlogPost blogPost = (BlogPost)_postRepo.GetAllPosts().Find(p => p.PostID == postID);

            // Edit the BlogPost
            blogPost.Title = title;
            blogPost.BodyText = bodyText;
        }

        public void ReturnBlogPosts(BlogPost bPost)
        {
        }
    }
}
