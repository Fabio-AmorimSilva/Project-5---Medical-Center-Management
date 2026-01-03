namespace MedicalCenterManagement.Domain.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadAsync(string path);
    Task<string> UploadAsync(string fileName, Stream fileStream);
    Task<Stream> DownloadAsync(string path);
    Task DeleteAsync(string path);
}