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
        public void CreateBlogPost(string title, string bodyText, Author author);
        public void EditBlogPost(string title, string bodyText, Guid postID);
    }
}
