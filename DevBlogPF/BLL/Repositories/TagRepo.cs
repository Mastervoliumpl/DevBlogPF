﻿using DevBlogPF.BLL.Interfaces;
using DevBlogPF.Models;

namespace DevBlogPF.BLL.Repositories
{
    public class TagRepo : ITagRepo
    {
        private List<Tag> _tags = [];

        public void CreateTag(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Tag name cannot be null or empty.");
            }
            Tag tag = new Tag(name);
            _tags.Add(tag);
        }

        public void DeleteTag(Tag tag)
        {
            Tag foundTag = _tags.Find(t => t.TagID == tag.TagID);
            if (foundTag != null)
            {
                _tags.Remove(foundTag);
            }
            else
            {
                throw new ArgumentException("Tag does not exist.");
            }
        }

        public List<Tag> GetTags()
        {
            return _tags;
        }

        public Tag GetTagByID(Guid tagID)
        {
            return _tags.Find(t => t.TagID == tagID);
        }
    }
}
