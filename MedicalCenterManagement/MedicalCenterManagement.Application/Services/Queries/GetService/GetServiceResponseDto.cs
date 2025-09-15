namespace MedicalCenterManagement.Application.Services.Queries.GetService;

public record GetServiceResponseDto
{
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public decimal Price { get; init; }
    public int Period { get; init; }
}