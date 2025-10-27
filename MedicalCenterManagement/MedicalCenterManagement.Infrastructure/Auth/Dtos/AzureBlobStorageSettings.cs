namespace MedicalCenterManagement.Infrastructure.Auth.Dtos;

public record AzureBlobStorageSettings
{
    public string ConnectionString { get; init; } = string.Empty;
    public string ContainerName { get; init; } = string.Empty;
}