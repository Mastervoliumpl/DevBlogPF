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
        public void CreateBlogPost(Author author, string title, string bodyText);
        public void EditBlogPost(string title, string bodyText, Guid postID);
        public void ReturnBlogPosts(BlogPost bPost);
    }
}
