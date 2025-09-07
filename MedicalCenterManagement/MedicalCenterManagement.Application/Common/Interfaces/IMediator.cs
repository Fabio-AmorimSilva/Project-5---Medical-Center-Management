namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface IMediator
{
    Task<TResponse> Publish<TResponse>(IRequest<TResponse> request);
}