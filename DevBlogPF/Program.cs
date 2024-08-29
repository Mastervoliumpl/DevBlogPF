using DevBlogPF.BLL.Interfaces;
using DevBlogPF.BLL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevBlogPF
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the dependency injection container
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IBlogPostRepo, BlogPostRepo>()
                .AddSingleton<IImageRepo, ImageRepo>()
                .AddSingleton<IPortfolioItemRepo, PortfolioItemRepo>()
                .AddSingleton<IPortfolioRepo, PortfolioRepo>()
                .AddSingleton<IPostRepo, TagListRepo>()
                .AddSingleton<ITagRepo, TagRepo>()
                .BuildServiceProvider();

            // Resolve the dependencies from the container
            var blogPostRepo = serviceProvider.GetService<IBlogPostRepo>();
            var imageRepo = serviceProvider.GetService<IImageRepo>();
            var portfolioItemRepo = serviceProvider.GetService<IPortfolioItemRepo>();
            var portfolioRepo = serviceProvider.GetService<IPortfolioRepo>();
            var tagListRepo = serviceProvider.GetService<IPostRepo>();
            var tagRepo = serviceProvider.GetService<ITagRepo>();

            blogPostRepo.CreateBlogPost();
        }
    }
}