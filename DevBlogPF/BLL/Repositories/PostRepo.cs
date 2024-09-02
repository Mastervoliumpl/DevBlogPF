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

        public void DeletePost(Guid postID)
        {
            // Find the post and delete the post
            _posts.Remove(GetAllPosts().Find(p => p.PostID == postID));
        }

        public List<Post> GetAllPosts()
        {
            return _posts;
        }

        public Post GetPostByID(Guid postID)
        {
            return _posts.Find(p => p.PostID == postID);
        }

        public void AddTagToTagList(Tag tag, Post post)
        {
            post.Tags.Add(tag);
        }

        public void RemoveTagFromList(Tag tag, Post post)
        {
            post.Tags.Remove(tag);
        }
    }
}
