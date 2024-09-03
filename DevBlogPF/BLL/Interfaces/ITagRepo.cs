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
        void CreateTag(string name);
        void DeleteTag(Tag tag);
        List<Tag> GetTags();
        Tag GetTagByID(Guid tagID);
    }
}
