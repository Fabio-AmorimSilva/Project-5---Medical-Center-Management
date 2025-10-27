namespace MedicalCenterManagement.Domain.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadAsync(Stream stream, string fileName, string contentType);
    Task<Stream> DownloadAsync(string fileName);
    Task DeleteAsync(string fileName);
}