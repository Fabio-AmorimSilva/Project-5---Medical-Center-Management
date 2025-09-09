namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface IHandler<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request);
}