using DevBlogPF.BLL.Interfaces;
using DevBlogPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogPF.BLL.Repositories
{
    public class TagRepo : ITagRepo
    {
        List<Tag> tags { get; set; } = new List<Tag>();
        public void CreateTag(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Tag name cannot be null or empty.");
            }
            Tag tag = new Tag(name);
            tags.Add(tag);
        }

        public void DeleteTag(Tag tag)
        {
            Tag foundTag = tags.Find(t => t.TagID == tag.TagID);
            if (foundTag != null)
            {
                tags.Remove(foundTag);
            }
            else
            {
                throw new ArgumentException("Tag does not exist.");
            }
        }

        public List<Tag> GetTags()
        {
            return tags;
        }
    }
}
