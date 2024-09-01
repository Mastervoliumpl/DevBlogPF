using DevBlogPF.Models;
using DevBlogPF.BLL.Interfaces;
using System;

namespace DevBlogPF.BLL.Repositories
{
    public class PostRepo : IPostRepo
    {
        private List<Post> _posts;

        public PostRepo()
        {
            _posts = new List<Post>();
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return _posts;
        }

        public void AddTagToTagList(Tag tag, Post post)
        {
            post.TagList.Tags.Add(tag);
        }

        public void RemoveTagFromList(Tag tag, Post post)
        {
            post.TagList.Tags.Remove(tag);
        }
    }
}
