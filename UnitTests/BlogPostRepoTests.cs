using DevBlogPF.BLL.Interfaces;
using DevBlogPF.BLL.Repositories;
using DevBlogPF.Models;
using Moq;

namespace UnitTests.Repositories
{
    public class BlogPostRepoTests
    {
        private readonly BlogPostRepo _blogPostRepo;

        /// <summary>
        /// Creates a mock of the IPostRepo interface. This allows to verify that the BlogPostRepo interacts with its dependencies correctly without needing implementation of IPostRepo.
        /// </summary>
        private readonly Mock<IPostRepo> _mockPostRepo; // Mock the IPostRepo dependency

        public BlogPostRepoTests()
        {
            _mockPostRepo = new Mock<IPostRepo>();
            _blogPostRepo = new BlogPostRepo(_mockPostRepo.Object); // Inject IPostRepo mock
        }

        [Fact]
        public void CreateBlogPost_ShouldAddBlogPostToPostRepo()
        {
            // Arrange
            var author = new Author("John", "Doe");
            string title = "Test Blog Post";
            string bodyText = "This is a test blog post body.";

            // Act
            _blogPostRepo.CreateBlogPost(title, bodyText, author);

            // Assert
            /// <summary>
            /// It.IsAny<T>() is used in the here to check that the AddPost method was called with any BlogPost object.
            /// </summary>
            _mockPostRepo.Verify(pr => pr.AddPost(It.IsAny<BlogPost>()), Times.Once);
        }

        [Fact]
        public void EditBlogPost_ShouldEditExistingBlogPost()
        {
            // Arrange
            var author = new Author("John", "Doe");
            string originalTitle = "Original Blog Post";
            string originalBodyText = "Original body text.";
            var blogPost = new BlogPost(originalTitle, author, originalBodyText);
            Guid postId = blogPost.PostID;

            // Mock the existing posts in the repository
            _mockPostRepo.Setup(pr => pr.GetAllPosts()).Returns(new List<Post> { blogPost });

            // Act
            _blogPostRepo.EditBlogPost("Updated Blog Post", "Updated body text.", postId);

            // Assert
            Assert.Equal("Updated Blog Post", blogPost.Title);
            Assert.Equal("Updated body text.", blogPost.BodyText);
            Assert.True(blogPost.DateModified > blogPost.DateCreated);
        }
    }
}
