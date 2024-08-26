namespace DevBlogPF.Models
{
    public class TagList
    {
        public Guid TagListID { get; set; }

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
