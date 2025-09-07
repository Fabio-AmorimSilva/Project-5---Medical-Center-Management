namespace MedicalCenterManagement.Application.Common;

public class Mediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> Publish<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic? handler = serviceProvider.GetService(handlerType);
        
        if(handler is null)
            throw new Exception($"Handler {handlerType} not found");
        
        return await handler.Handle(request);
    }
}