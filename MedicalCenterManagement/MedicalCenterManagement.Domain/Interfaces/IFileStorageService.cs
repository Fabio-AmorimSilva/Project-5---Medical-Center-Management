namespace MedicalCenterManagement.Domain.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadAsync(string path);
    Task<Stream> DownloadAsync(string path);
    Task DeleteAsync(string path);
}