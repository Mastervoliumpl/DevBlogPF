using DevBlogPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Interfaces
{
    public interface IPortfolioItemRepo
    {
        public void CreatePortfolioPost();
        public void UpdatePortfolioPost();
        public void DeletePortfolioPost();
        public void SetTagListPortfolioPost(Post postObj, TagList tagList);
        public void RemoveTagListPortfolioPost(Post postObj);
    }
}
