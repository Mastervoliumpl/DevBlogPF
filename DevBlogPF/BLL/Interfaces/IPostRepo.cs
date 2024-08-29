using DevBlogPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Interfaces
{
    public interface IPostRepo
    {
        public void AddTag(Tag tag);
        public void RemoveTag(Tag tag);
    }
}
