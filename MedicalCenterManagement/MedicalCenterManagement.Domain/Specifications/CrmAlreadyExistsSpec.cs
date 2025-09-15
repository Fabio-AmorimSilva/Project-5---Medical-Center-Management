namespace MedicalCenterManagement.Domain.Specifications;

public sealed class CrmAlreadyExistsSpec : Specification<Doctor>
{
    public CrmAlreadyExistsSpec(Guid doctorId, string crm)
    {
        Query.Where(d =>
            d.Id != doctorId &&
            d.Crm == crm
        );
    }
}