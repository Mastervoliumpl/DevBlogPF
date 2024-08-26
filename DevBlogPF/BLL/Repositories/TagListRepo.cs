using DevBlogPF.Models;
using DevBlogPF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Repositories
{
    public class TagListRepo : ITagListRepo
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }

        public void RemoveTag(Tag tag)
        {
            Tags.Remove(tag);
        }
    }
}
