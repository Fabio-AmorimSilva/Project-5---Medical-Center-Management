namespace MedicalCenterManagement.Domain.Common;

public interface IHasIsDeleted
{
    bool IsDeleted { get; set; }
}