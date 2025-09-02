namespace MedicalCenterManagement.Domain.Common;

public interface IHasIsDeleted
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}