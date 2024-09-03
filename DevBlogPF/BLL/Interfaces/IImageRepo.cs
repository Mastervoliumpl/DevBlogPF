using DevBlogPF.Models;

namespace DevBlogPF.BLL.Interfaces
{
    public interface IImageRepo
    {
        void UploadImage();
        void DeleteImage();
    }
}
