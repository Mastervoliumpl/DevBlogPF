global using System;
using DevBlogPF.BLL.Interfaces;
using DevBlogPF.BLL.Repositories;
using DevBlogPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

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
                .AddSingleton<IPortfolioRepo, PortfolioRepo>()
                .AddSingleton<ITagRepo, TagRepo>()
                .AddSingleton<IPostRepo, PostRepo>()
                .BuildServiceProvider();

            // Resolve the dependencies from the container
            var blogPostRepo = serviceProvider.GetService<IBlogPostRepo>();
            var imageRepo = serviceProvider.GetService<IImageRepo>();
            var portfolioRepo = serviceProvider.GetService<IPortfolioRepo>();
            var postRepo = serviceProvider.GetService<IPostRepo>();
            var tagRepo = serviceProvider.GetService<ITagRepo>();

            ConsoleKeyInfo keyinfo;
            do
            {
                DisplayMenu();
                keyinfo = ReadKey(true); // Reading a key press from the user without displaying it in the console.

                switch (keyinfo.KeyChar)
                {
                    case '1':
                        CreateTag();
                        break;
                    case '2':
                        DisplayAllTags();
                        break;
                    case '3':
                        CreateBlogPost();
                        break;
                    case '4':
                        //EditBlogPost();
                        break;
                    case '5':
                        DisplayAllPosts();
                        break;
                    case '6':
                        
                        break;
                    case 'x':
                        WriteLine("Exiting...");
                        break;
                    default:
                        // Handles invalid input.
                        WriteLine("Incorrect choice. Try again.");
                        break;
                }

                WriteLine("Press any to continue...");
                ReadKey();

            } while (keyinfo.KeyChar != 'x'); // Loop continues until 'x' is pressed.

            void DisplayMenu()
            {
                Clear();
                WriteLine("----------------------------");
                WriteLine("Choose one of the following:");
                WriteLine("1 - Create Tag");
                WriteLine("2 - Return all Tags");
                WriteLine("3 - Create blog post");
                WriteLine("4 - N/A");
                WriteLine("5 - Diplay all posts");
                WriteLine("6 - N/A");
                WriteLine("x - Exit");
                WriteLine("----------------------------");
            }

            void CreateTag()
            {
                // Get the tag name from the user
                WriteLine("Enter the name of the tag:");
                string name = ReadLine();

                // Remove spaces from the tag name
                name = name.Replace(" ", "");

                // Create a new tag
                tagRepo.CreateTag(name);
            }

            void DisplayAllTags()
            {
                // Get all tags from the database
                var tags = tagRepo.GetTags();

                // Check if there are no tags
                if (tags.Count == 0)
                {
                    WriteLine("No tags found.");
                }
                else
                {
                    // Display all tags
                    foreach (Models.Tag? tag in tags)
                    {
                        WriteLine($"Tag Name: {tag.TagName}, Tag ID: {tag.TagID}");
                    }
                }
            }

            void CreateBlogPost()
            {
                // Get the data for the blog post from the user
                WriteLine("Enter the title of the post:");
                string title = ReadLine();

                WriteLine("Enter the author's first name:");
                string firstName = ReadLine();

                WriteLine("Enter the author's last name:");
                string lastName = ReadLine();

                // Create the author object
                var author = new Author(firstName, lastName);

                // Get the post body text from the user
                WriteLine("Enter the body text of the post:");
                string bodyText = ReadLine();

                // Create a new post
                blogPostRepo.CreateBlogPost(author, title, bodyText);
            }

            void DisplayAllPosts()
            {
                // Get all posts from the database
                var posts = postRepo.GetAllPosts();

                if (posts.Count == 0)
                {
                    WriteLine("No posts found.");
                }
                else
                {
                    // Display all posts
                    foreach (var post in posts)
                    {
                        if (post.PostType == PostType.BlogPost)
                        {
                            BlogPost viewPost = (BlogPost)post;
                            WriteLine($"Post Title: {viewPost.Title}, Post ID: {viewPost.PostID}, Post Type: {viewPost.PostType}");
                        }
                        else
                        {
                            Portfolio viewPost = (Portfolio)post;
                            WriteLine($"Post Title: {viewPost.Title}, Post ID: {viewPost.PostID}, Post Type: {viewPost.PostType}");
                        }
                    }
                }
            }
        }
    }
}