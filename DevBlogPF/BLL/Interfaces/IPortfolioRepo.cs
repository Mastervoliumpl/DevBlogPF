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
        public void CreatePortfolioPost();
        public void EditPortfolioPost();
        public void DeletePortfolioPost();
    }
}
