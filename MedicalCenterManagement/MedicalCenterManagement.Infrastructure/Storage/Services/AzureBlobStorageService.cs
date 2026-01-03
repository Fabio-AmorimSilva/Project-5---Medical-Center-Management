namespace MedicalCenterManagement.Infrastructure.Storage.Services;

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
    
    public async Task<string> UploadAsync(string path)
    {
        var blobClient = _blobContainerClient.GetBlobClient(path);
        
        var stream = new MemoryStream();
        
        await blobClient.UploadAsync(stream);
        
        return blobClient.Uri.ToString();
    }

    public async Task<Stream> DownloadAsync(string path)
    {
        var blobClient = _blobContainerClient.GetBlobClient(path);
        
        var download = await blobClient.DownloadAsync();
        
        return download.Value.Content;
    }

    public Task DeleteAsync(string path)
    {
        var blobClient = _blobContainerClient.GetBlobClient(path);
        
        return blobClient.DeleteAsync();
    }
}