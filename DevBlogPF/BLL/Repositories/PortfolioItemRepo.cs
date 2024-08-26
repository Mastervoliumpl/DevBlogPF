using DevBlogPF.Models;
using DevBlogPF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Repositories
{
    public class PortfolioItemRepo : IPortfolioItemRepo
    {
        private List<PortfolioItem> _portfolioItemList = new();

        public object PostID { get; set; }

        public void CreatePortfolioPost()
        {

        }

        public void EditPortfolioPost()
        {

        }

        public void DeletePortfolioPost()
        {

        }

        public void UpdatePortfolioPost()
        {

        }

        public void SetTagListPortfolioPost(Post postObj, TagList tagList)
        {
            postObj.TagList = tagList;
        }

        public void RemoveTagListPortfolioPost(Post postObj)
        {
            postObj.TagList = null;
        }
    }
}
