using DevBlogPF.Models;

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
