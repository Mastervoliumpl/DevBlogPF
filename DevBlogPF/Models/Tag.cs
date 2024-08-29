namespace DevBlogPF.Models
{
    public class Tag
    {
        public Guid TagID { get; set; }
        public string TagName { get; set; }
        public Tag(string name)
        {
            TagID = Guid.NewGuid();
            TagName = name;
        }
    }
}
