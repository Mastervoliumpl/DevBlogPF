using DevBlogPF.Models;
using DevBlogPF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Repositories
{
    public class PortfolioRepo : IPortfolioRepo
    {
        private readonly IPostRepo _postRepo;

        public PortfolioRepo(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public void CreatePortfolioPost(string title, string description, Author author)
        {
            // Create a new PortfolioPost
            Portfolio portfolioPost = new Portfolio(title, description, author);
            _postRepo.AddPost(portfolioPost);
        }

        public void EditPortfolioPost(string title, string description, Guid postID)
        {
            // Find the PortfolioPost
            Portfolio portfolioPost = (Portfolio)_postRepo.GetAllPosts().Find(p => p.PostID == postID);

            // Edit the PortfolioPost
            portfolioPost.Title = title;
            portfolioPost.Description = description;
        }
    }
}
