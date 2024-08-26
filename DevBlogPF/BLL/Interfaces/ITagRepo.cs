using DevBlogPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Interfaces
{
    public interface ITagRepo
    {
        public void CreateTag();
        public void DeleteTag();
        public void UpdateTag();
    }
}
