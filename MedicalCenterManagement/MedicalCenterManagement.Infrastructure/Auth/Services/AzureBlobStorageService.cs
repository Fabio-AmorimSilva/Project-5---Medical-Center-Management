namespace MedicalCenterManagement.Infrastructure.Auth.Services;

public class AzureBlobStorageService : IFileStorageService
{
    private readonly BlobContainerClient _blobContainerClient;
    
    public AzureBlobStorageService(
        string? connectionString,
        string? containerName
    )
    {
        _blobContainerClient = new BlobContainerClient(
            connectionString: connectionString,
            blobContainerName: containerName
        );
        
        _blobContainerClient.CreateIfNotExists(PublicAccessType.Blob);
    }
    
    public async Task<string> UploadAsync(Stream stream, string fileName, string contentType)
    {
        var blobClient = _blobContainerClient.GetBlobClient(fileName);
        var headers = new BlobHttpHeaders
        {
            ContentType = contentType
        };
        await blobClient.UploadAsync(stream, headers);
        
        return blobClient.Uri.ToString();
    }

    public async Task<Stream> DownloadAsync(string fileName)
    {
        var blobClient = _blobContainerClient.GetBlobClient(fileName);
        var download = await blobClient.DownloadAsync();
        
        return download.Value.Content;
    }

    public Task DeleteAsync(string fileName)
    {
        var blobClient = _blobContainerClient.GetBlobClient(fileName);
        
        return blobClient.DeleteAsync();
    }
}