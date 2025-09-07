namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface IHandler<TRequest, TResponse>
{
    Task<TResponse> Handle(IRequest request);
}