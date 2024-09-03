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
        void DeletePost(Guid postID);
        List<Post> GetAllPosts();
        Post GetPostByID(Guid postID);
        List<Tag> GetTagsByPostID(Guid postID);
        void AddTagToTagList(Tag tag, Guid postID);
        void RemoveTagFromList(Tag tag, Guid postID);
    }
}
