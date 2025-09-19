namespace MedicalCenterManagement.Application.MedicalCares.Queries.GetMedicalCare;

public record GetMedicalCareResponseDto
{
    public string Insurance { get; init; } = null!;
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public TypeOfService TypeOfService { get; init; }
    public string Patient { get; init; } = null!;
    public string Doctor { get; init; } = null!;
    public string Service { get; init; } = null!;
}