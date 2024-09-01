using DevBlogPF.Models;
using DevBlogPF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Repositories
{
    public class PortfolioRepo : IPortfolioRepo
    {
        private List<Portfolio> _portfolioList = new();

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
    }
}
