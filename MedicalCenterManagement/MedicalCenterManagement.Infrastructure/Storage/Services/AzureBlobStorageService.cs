namespace MedicalCenterManagement.Infrastructure.Storage.Services;

public class AzureBlobStorageService : IFileStorageService
{
    private readonly BlobContainerClient _blobContainerClient;
    
    public AzureBlobStorageService(
        string? connectionString,
        string? containerName
    )
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentNullException(nameof(connectionString), "Azure Blob Storage connection string is required");

        if (string.IsNullOrWhiteSpace(containerName))
            throw new ArgumentNullException(nameof(containerName), "Azure Blob Storage container name is required");

        try
        {
            _blobContainerClient = new BlobContainerClient(
                connectionString: connectionString,
                blobContainerName: containerName
            );
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                $"Failed to initialize Azure Blob Storage client. ConnectionString: {(string.IsNullOrEmpty(connectionString) ? "NULL" : "PROVIDED")}, ContainerName: {containerName}",
                ex
            );
        }
    }
    
    public async Task<string> UploadAsync(string path)
    {
        var blobClient = _blobContainerClient.GetBlobClient(path);

        var stream = new MemoryStream();

        await blobClient.UploadAsync(stream);

        return blobClient.Uri.ToString();
    }

    public async Task<string> UploadAsync(string fileName, Stream fileStream)
    {
        await _blobContainerClient.CreateIfNotExistsAsync();

        var blobClient = _blobContainerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(fileStream);

        return blobClient.Uri.ToString();
    }

    public async Task<Stream> DownloadAsync(string path)
    {
        var blobClient = _blobContainerClient.GetBlobClient(path);
        
        var stream = new MemoryStream();
        
        await blobClient.DownloadToAsync(stream);
        
        stream.Position = 0;

        return stream;
    }

    public Task DeleteAsync(string path)
    {
        var blobClient = _blobContainerClient.GetBlobClient(path);
        
        return blobClient.DeleteAsync();
    }
}