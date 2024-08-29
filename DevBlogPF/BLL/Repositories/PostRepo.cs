using DevBlogPF.Models;
using DevBlogPF.BLL.Interfaces;
using System;

namespace DevBlogPF.BLL.Repositories
{
    public class PostRepo : IPostRepo
    {
        private List<Post> _posts;

        public PostRepo()
        {
            _posts = new List<Post>();
        }

        public void AddTagToTagList(Tag tag, Post post)
        {

            Post foundPost = _posts.Find(t => t.PostID == post.PostID);
            if (foundPost != null)
            {
                
                listOfTags.Add(tag);
            }
            else
            {
                throw new ArgumentException("TagList does not exist.");
            }
        }

        public void RemoveTagFromList(Tag tag, TagList tagList)
        {
            TagList foundTagList = TagLists.Find(t => t.TagListID == tagList.TagListID);
            if (foundTagList != null)
            {
                Tag foundTag = _tagRepo.tags.Find(t => t.TagID == tag.TagID);
                if (foundTag != null)
                {

                }
                else
                {
                    throw new ArgumentException("Tag does not exist.");
                }
            }
            else
            {
                throw new ArgumentException("TagList does not exist.");
            }
        }
    }
}
