namespace MedicalCenterManagement.Domain.Specifications;

public sealed class ServiceAlreadyExistsSpec : Specification<Service>
{
    public ServiceAlreadyExistsSpec(Guid serviceId, string name)
    {
        Query.Where(s =>
            s.Id != serviceId &&
            s.Name == name
        );
    }
}