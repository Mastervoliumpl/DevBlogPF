﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlogPF.BLL.Interfaces;
using DevBlogPF.Models;

namespace DevBlogPF.BLL.Repositories
{
    public class BlogPostRepo(IPostRepo postRepo) : IBlogPostRepo
    {
        private readonly IPostRepo _postRepo = postRepo;

        public void CreateBlogPost(string title, string bodyText, Author author)
        {
            // Create a new BlogPost
            BlogPost blogPost = new BlogPost(title, author, bodyText);
            _postRepo.AddPost(blogPost);
        }

        public void EditBlogPost(string title, string bodyText, Guid postID)
        {
            // Find the BlogPost
            BlogPost blogPost = (BlogPost)_postRepo.GetAllPosts().Find(p => p.PostID == postID);

            // Edit the BlogPost
            blogPost.Title = title;
            blogPost.BodyText = bodyText;
            blogPost.DateModified = DateTimeOffset.Now;
        }
    }
}
