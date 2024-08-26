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
        public PortfolioItem PortfolioItem { get; set; } = new PortfolioItem(); // Add a property to hold the PortfolioItem object
        public List<PortfolioItemRepo> Items { get; set; } = new List<PortfolioItemRepo>();

        public void AddPortfolioItem(PortfolioItemRepo portfolioItem)
        {
            portfolioItem.PostID = Guid.NewGuid(); // Assign a new unique Guid to the portfolioItem
            Items.Add(portfolioItem);
        }

        public void UpdatePortfolioItem(PortfolioItemRepo portfolioItem)
        {
            PortfolioItemRepo existingItem = Items.Find(item => item.PostID == portfolioItem.PostID);
            if (existingItem != null)
            {
                // Update the properties of the existing item with the new values
                //existingItem.Property1 = portfolioItem.Property1;
            }
            else
            {
                // Handle the case when the item is not found
                // You can throw an exception or handle it in a way that makes sense for your application
            }
        }

        public void DeletePortfolioItem(PortfolioItemRepo portfolioItem)
        {
            Items.Remove(portfolioItem);
        }
    }
}
