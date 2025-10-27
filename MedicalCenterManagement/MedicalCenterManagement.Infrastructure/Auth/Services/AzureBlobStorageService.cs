using Azure.Storage.Blobs;
using MedicalCenterManagement.Domain.Interfaces;

namespace MedicalCenterManagement.Infrastructure.Auth.Services;

public class AzureBlobStorageService(
    IOptions<AzureBlobStorageSettings> options,    
    BlobContainerClient containerClient
) : IFileStorageService
{
    private readonly AzureBlobStorageSettings _azureBlobStorageSettings = options.Value;
    
    public Task<string> UploadAsync(Stream stream, string fileName, string contentType)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadAsync(string fileName)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string fileName)
    {
        throw new NotImplementedException();
    }
}