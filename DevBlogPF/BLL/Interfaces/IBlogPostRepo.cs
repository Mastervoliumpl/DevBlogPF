using DevBlogPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Interfaces
{
    public interface IBlogPostRepo
    {
        public void CreateBlogPost();
        public void UpdateBlogPost();
        public void DeleteBlogPost();
        public void SetTagListBlogPost(Post postObj, TagList tagList);
        public void RemoveTagListBlogPost(Post postObj);
    }
}
