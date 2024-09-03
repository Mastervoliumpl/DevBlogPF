﻿namespace DevBlogPF.Models
{
    public abstract class Post
    {
        public Guid PostID { get; init; } = Guid.NewGuid();
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;
        public Author Author { get; set; }
        public List<Tag> Tags { get; set; } = []; // means the same as new "List<Tag>();"
        public List<Image> Images { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
        public PostType PostType { get; set; }
        public string Title { get; set; }

        public Post(Author author)
        {
            Author = author;
        }
    }

    public enum PostType
    {
        BlogPost,
        Portfolio
    }
}
