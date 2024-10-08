﻿namespace DevBlogPF.Models
{
    public abstract class Post
    {
        public Guid PostID { get; set; }
        public DateTime DateCreated { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public TagList TagList { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}
