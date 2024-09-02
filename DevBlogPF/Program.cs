global using System;
using DevBlogPF.BLL.Interfaces;
using DevBlogPF.BLL.Repositories;
using DevBlogPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
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
                        CreatePost();
                        break;
                    case '4':
                        EditPost();
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
                WriteLine("2 - Display all Tags");
                WriteLine("3 - Create post");
                WriteLine("4 - Edit post");
                WriteLine("5 - Diplay all posts");
                WriteLine("6 - N/A");
                WriteLine("x - Exit");
                WriteLine("----------------------------");
            }

            void CreateTag()
            {
                // Get the tag name from the user
                string name = ReadValidStringInput("Enter the name of the tag:");

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

            void CreatePost()
            {
                ConsoleKeyInfo keyinfo;

                Clear();
                WriteLine("Choose post type:");
                WriteLine("1 - BlogPost");
                WriteLine("2 - Portfolio");
                WriteLine("x - Exit");
                keyinfo = ReadKey(true);

                switch (keyinfo.KeyChar)
                {
                    case '1':
                        // Get the data for the blog post from the user
                        Clear();
                        string title = ReadValidStringInput("Enter the title of the post:");
                        string firstName = ReadValidStringInput("Enter the author's first name:");
                        string lastName = ReadValidStringInput("Enter the author's last name:");

                        // Create the author object
                        var author = new Author(firstName, lastName);

                        // Get the post body text from the user
                        WriteLine("Enter the body text of the post:");
                        string bodyText = ReadLine();

                        // Create a new post
                        blogPostRepo.CreateBlogPost(author, title, bodyText);

                        WriteLine("Post created successfully!");
                        break;
                    case '2':

                        WriteLine("NotImplemented!");
                        break;
                    default:
                        WriteLine("Incorrect choice. Try again.");
                        break;
                }
            }

            void EditPost()
            {
                Guid postID;
                bool isValidGuid = false;

                do
                {
                    Clear();
                    WriteLine("Enter the ID of the post you want to edit: (x to exit)");
                    string input = ReadLine();

                    if (input.ToLower() == "x")
                    {
                        return; // Return to the menu if 'x' is entered
                    }

                    isValidGuid = Guid.TryParse(input, out postID);

                    if (!isValidGuid)
                    {
                        WriteLine("Invalid GUID format. Please try again.");
                        WriteLine("Press any key to continue...");
                        ReadKey();
                    }
                } while (!isValidGuid);

                ConsoleKeyInfo keyinfo;

                Clear();
                WriteLine("Choose post type:");
                WriteLine("1 - BlogPost");
                WriteLine("2 - Portfolio");
                WriteLine("x - Exit");
                keyinfo = ReadKey(true);

                switch (keyinfo.KeyChar)
                {
                    case '1':
                        // Get the existing post from the repository
                        var existingPost = (BlogPost)postRepo.GetPostByID(postID);

                        if (existingPost == null)
                        {
                            Clear();
                            WriteLine("Post not found.");
                            return;
                        }

                        // Display the current values of the post
                        Clear();
                        WriteLine("Current Post Details:");
                        WriteLine($"Title: {existingPost.Title}");
                        WriteLine($"Author: {existingPost.Author.FirstName} {existingPost.Author.LastName}");
                        WriteLine($"Body Text: {existingPost.BodyText}");

                        // Prompt the user for new values
                        string newTitle = ReadValidStringInput("Enter the new title of the post:");
                        string newBodyText = ReadValidStringInput("Enter the new body text of the post:");

                        // Update the post
                        blogPostRepo.EditBlogPost(newTitle, newBodyText, postID);

                        Clear();
                        WriteLine("Post updated successfully.");
                        break;
                    case '2':

                        WriteLine("NotImplemented!");
                        break;
                    default:
                        WriteLine("Incorrect choice. Try again.");
                        break;
                }
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
                            WriteLine($"Post Title: {viewPost.Title}, Post ID: {viewPost.PostID}, Post Type: {viewPost.PostType}, Post Created: {viewPost.DateCreated}, Post Body: {viewPost.BodyText}");
                        }
                        else
                        {
                            Portfolio viewPost = (Portfolio)post;
                            WriteLine($"Post Title: {viewPost.Title}, Post ID: {viewPost.PostID}, Post Type: {viewPost.PostType}, Post Created: {viewPost.DateCreated}, Post Description: {viewPost.Description}");
                        }
                    }
                }
            }
        }

        public static string ReadValidStringInput(string prompt)
        {
            string input;
            do
            {
                WriteLine(prompt);
                input = ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}