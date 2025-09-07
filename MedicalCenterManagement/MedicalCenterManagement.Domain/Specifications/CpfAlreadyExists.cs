namespace MedicalCenterManagement.Domain.Specifications;

public class CpfAlreadyExists : Specification<IHasCpf>
{
    public CpfAlreadyExists(string cpf)
    {
        Query.Where(e => e.Cpf == cpf);
    }
}