using DevBlogPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Interfaces
{
    public interface IPortfolioRepo
    {
        void CreatePortfolioPost(string title, string description, Author author);
        void EditPortfolioPost(string title, string description, Guid postID);
    }
}
