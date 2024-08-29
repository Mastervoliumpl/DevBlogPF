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
        void AddTagToTagList(Tag tag, Post post);
        void RemoveTagFromList(Tag tag, Post post);
    }
}
