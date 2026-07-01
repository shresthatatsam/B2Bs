using B2B.Services.Interfaces;

namespace B2B.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;

        public ImageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Uploads",
                folderName);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string fileName =
                $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/Uploads/{folderName}/{fileName}";
        }

    public async Task<bool> DeleteAsync(string imageUrl, string folderName)
        {
            try
            {
                if (string.IsNullOrEmpty(imageUrl))
                    return false;

                // Example: /uploads/products/abc.jpg
                string fileName = Path.GetFileName(imageUrl);

                string filePath = Path.Combine(
                    _environment.WebRootPath,
                    "uploads",
                    folderName,
                    fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

