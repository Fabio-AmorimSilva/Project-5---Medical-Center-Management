namespace MedicalCenterManagement.Application.Services.Queries.ListServices;

public record ListServicesResponseDto
{
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public decimal Price { get; init; }
    public int Period { get; init; }
}