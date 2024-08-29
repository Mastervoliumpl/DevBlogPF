using System.Net.Quic;

namespace DevBlogPF.Models
{
    public class TagList
    {
        public Guid TagListID { get; set; }
        public Guid PostID { get; init; }
        public List<Tag> Tags { get; set; }

        public TagList(Guid postID)
        {
            TagListID = Guid.NewGuid();
            PostID = postID;
            Tags = []; // means the same as new "List<Tag>();"
        }
    }
}
