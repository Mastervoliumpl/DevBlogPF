﻿namespace DevBlogPF.Models
{
    public class Image
    {
        public Guid ImageID { get; set; }
        public byte[] ImageFile { get; set; } // or string ImageFilePath depending on your choice
        public string ImageSource { get; set; }

        public void UploadImage()
        {
            // Implementation for uploading image
        }

        public void DeleteImage()
        {
            // Implementation for deleting image
        }
    }
}
