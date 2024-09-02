using DevBlogPF.BLL.Repositories;
using DevBlogPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Interfaces
{
    public interface IPostRepo
    {
        void AddPost(Post post);
        void RemovePost(Post post);
        List<Post> GetAllPosts();
        public Post GetPostByID(Guid postID);
        void AddTagToTagList(Tag tag, Post post);
        void RemoveTagFromList(Tag tag, Post post);
    }
}
