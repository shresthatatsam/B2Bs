namespace B2B.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadAsync(IFormFile file, string folderName);
        Task<bool> DeleteAsync(string imageUrl, string folderName);
    }
}
