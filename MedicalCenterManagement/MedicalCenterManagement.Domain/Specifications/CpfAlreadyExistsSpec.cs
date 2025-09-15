namespace MedicalCenterManagement.Domain.Specifications;

public sealed class CpfAlreadyExistsSpec : Specification<IHasCpf>
{
    public CpfAlreadyExistsSpec(string cpf)
    {
        Query.Where(e => e.Cpf == cpf);
    }
}