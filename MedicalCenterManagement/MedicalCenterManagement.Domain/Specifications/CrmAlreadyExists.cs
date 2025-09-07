namespace MedicalCenterManagement.Domain.Specifications;

public class CrmAlreadyExists : Specification<Doctor>
{
    public CrmAlreadyExists(Guid doctorId, string crm)
    {
        Query.Where(d =>
            d.Id != doctorId &&
            d.Crm == crm
        );
    }
}