using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlogPF.BLL.Interfaces;
using DevBlogPF.Models;

namespace DevBlogPF.BLL.Repositories
{
    public class BlogPostRepo : IBlogPostRepo
    {
        public object PostID { get; set; }
        private List<BlogPost> _blogPostList = new();

        public void CreateBlogPost()
        {

        }

        public void UpdateBlogPost()
        {

        }

        public void DeleteBlogPost()
        {

        }

        public void SetTagListBlogPost(Post postObj, TagList tagList)
        {
            postObj.TagList = tagList;
        }

        public void RemoveTagListBlogPost(Post postObj)
        {
            postObj.TagList = null;
        }
    }
}
