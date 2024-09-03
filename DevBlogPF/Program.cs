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
        static void Main()
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

            // Null checks
            if (blogPostRepo == null)
            {
                throw new InvalidOperationException("IBlogPostRepo service could not be resolved.");
            }

            if (imageRepo == null)
            {
                throw new InvalidOperationException("IImageRepo service could not be resolved.");
            }

            if (portfolioRepo == null)
            {
                throw new InvalidOperationException("IPortfolioRepo service could not be resolved.");
            }

            if (postRepo == null)
            {
                throw new InvalidOperationException("IPostRepo service could not be resolved.");
            }

            if (tagRepo == null)
            {
                throw new InvalidOperationException("ITagRepo service could not be resolved.");
            }

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
                        DeletePost();
                        break;
                    case '6':
                        DisplayAllPosts();
                        break;
                    case '7':
                        AddTagToPost();
                        break;
                    case '8':
                        RemoveTagFromPost();
                        break;
                    case '9':
                        DisplayPostsTags();
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
                WriteLine("5 - Delete post");
                WriteLine("6 - Diplay all posts");
                WriteLine("7 - Add tag to post");
                WriteLine("8 - Remove tag from post");
                WriteLine("9 - Display post tags");
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
                    foreach (var tag in tags)
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
                        string titleB = ReadValidStringInput("Enter the title of the post:");
                        string firstNameB = ReadValidStringInput("Enter the author's first name:");
                        string lastNameB = ReadValidStringInput("Enter the author's last name:");
                        string bodyTextB = ReadValidStringInput("Enter the body text of the post:");

                        // Create the author object
                        var authorB = new Author(firstNameB, lastNameB);

                        // Create a new blog post
                        blogPostRepo.CreateBlogPost(titleB, bodyTextB, authorB);

                        WriteLine("Post created successfully!");
                        break;
                    case '2':
                        string titleP = ReadValidStringInput("Enter the title of the post:");
                        string firstNameP = ReadValidStringInput("Enter the author's first name:");
                        string lastNameP = ReadValidStringInput("Enter the author's last name:");
                        string descriptionP = ReadValidStringInput("Enter the description of the post:");

                        var authorP = new Author(firstNameP, lastNameP);

                        // Create a new portfolio post
                        portfolioRepo.CreatePortfolioPost(titleP, descriptionP, authorP);

                        WriteLine("Post created successfully!");
                        break;
                    default:
                        WriteLine("Incorrect choice. Try again.");
                        break;
                }
            }

            void EditPost()
            {
                Guid postID;
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
                        // Get the post ID from the user
                        postID = ReadValidGuidInput("Enter the ID of the blog post to edit:");

                        // Get the existing post from the repository
                        var existingBlogPost = (BlogPost)postRepo.GetPostByID(postID);

                        if (existingBlogPost == null)
                        {
                            Clear();
                            WriteLine("Post not found.");
                            return;
                        }

                        // Display the current values of the post
                        Clear();
                        WriteLine("Current Post Details:");
                        WriteLine($"Title: {existingBlogPost.Title}");
                        WriteLine($"Author: {existingBlogPost.Author.FirstName} {existingBlogPost.Author.LastName}");
                        WriteLine($"Body Text: {existingBlogPost.BodyText}");

                        // Prompt the user for new values
                        string newTitleB = ReadValidStringInput("Enter the new title of the post:");
                        string newBodyTextB = ReadValidStringInput("Enter the new body text of the post:");

                        // Update the post
                        blogPostRepo.EditBlogPost(newTitleB, newBodyTextB, postID);

                        Clear();
                        WriteLine("Post updated successfully.");
                        break;
                    case '2':
                        // Get the post ID from the user
                        postID = ReadValidGuidInput("Enter the ID of the blog post to edit:");

                        // Get the existing post from the repository
                        var existingPortfolioPost = (Portfolio)postRepo.GetPostByID(postID);

                        if (existingPortfolioPost == null)
                        {
                            Clear();
                            WriteLine("Post not found.");
                            return;
                        }

                        // Display the current values of the post
                        Clear();
                        WriteLine("Current Post Details:");
                        WriteLine($"Title: {existingPortfolioPost.Title}");
                        WriteLine($"Author: {existingPortfolioPost.Author.FirstName} {existingPortfolioPost.Author.LastName}");
                        WriteLine($"Description: {existingPortfolioPost.Description}");

                        // Prompt the user for new values
                        string newTitleP = ReadValidStringInput("Enter the new title of the post:");
                        string newBodyTextP = ReadValidStringInput("Enter the new description of the post:");

                        // Update the post
                        portfolioRepo.EditPortfolioPost(newTitleP, newBodyTextP, postID);

                        Clear();
                        WriteLine("Post updated successfully.");
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
                            WriteLine($"Post Title: {viewPost.Title}, Post ID: {viewPost.PostID}, Post Type: {viewPost.PostType}, Post Created: {viewPost.DateCreated}, Post Modified: {viewPost.DateModified}, Post Body: {viewPost.BodyText}");
                        }
                        else
                        {
                            Portfolio viewPost = (Portfolio)post;
                            WriteLine($"Post Title: {viewPost.Title}, Post ID: {viewPost.PostID}, Post Type: {viewPost.PostType}, Post Created: {viewPost.DateCreated}, Post Modified: {viewPost.DateModified}, Post Description: {viewPost.Description}");
                        }
                    }
                }
            }

            void DeletePost()
            {
                // Get the post ID from the user
                Guid postID = ReadValidGuidInput("Enter the ID of the blog post to delete:");

                // Get the existing post from the repository
                var existingPost = postRepo.GetPostByID(postID);

                if (existingPost == null)
                {
                    WriteLine("Post not found.");
                    return;
                }

                // Delete the post
                postRepo.DeletePost(postID);

                WriteLine("Post deleted successfully.");
                       
            }

            void AddTagToPost()
            {
                // Get input from user
                Guid tagID = ReadValidGuidInput("Enter the ID of the tag:");
                Guid postID = ReadValidGuidInput("Enter the ID of the post:");

                // Get the existing post from the repository
                var existingPost = postRepo.GetPostByID(postID);

                if (existingPost == null)
                {
                    WriteLine("Post not found.");
                    return;
                }

                // Get the existing tag from the repository
                var existingTag = tagRepo.GetTagByID(tagID);

                if (existingTag == null)
                {
                    WriteLine("Tag not found.");
                    return;
                }

                // Add the tag to the post
                postRepo.AddTagToTagList(existingTag, postID);

                WriteLine("Tag added to post successfully.");
            }

            void RemoveTagFromPost() 
            {
                // Get input from user
                Guid tagID = ReadValidGuidInput("Enter the ID of the tag:");
                Guid postID = ReadValidGuidInput("Enter the ID of the post:");

                // Get the existing post from the repository
                var existingPost = postRepo.GetPostByID(postID);

                if (existingPost == null)
                {
                    WriteLine("Post not found.");
                    return;
                }

                // Get the existing tag from the repository
                var existingTag = tagRepo.GetTagByID(tagID);

                if (existingTag == null)
                {
                    WriteLine("Tag not found.");
                    return;
                }

                // Remove the tag from the post
                postRepo.RemoveTagFromList(existingTag, postID);

                WriteLine("Tag removed from post successfully.");
            }

            void DisplayPostsTags()
            {
                // Get all posts from the database
                Guid postID = ReadValidGuidInput("Enter the ID of the post:");

                var existingTags = postRepo.GetTagsByPostID(postID);

                if (existingTags == null)
                {
                    WriteLine("No tags found.");
                    return;
                }
                else if (existingTags.Count == 0)
                {
                    WriteLine("No tags found.");
                    return;
                }
                else
                {
                    // Display all tags from a post
                    foreach (var tag in existingTags)
                    {
                        WriteLine($"Tag Name: {tag.TagName}, Tag ID: {tag.TagID}");
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

        public static Guid ReadValidGuidInput(string prompt)
        {
            Guid input;
            bool isValidGuid;

            do
            {
                WriteLine(prompt);
                isValidGuid = Guid.TryParse(ReadLine(), out input);
            } while (!isValidGuid);

            return input;
        }
    }
}