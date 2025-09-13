namespace MedicalCenterManagement.Application.Common;

public class Mediator(IServiceScopeFactory scopeFactory) : IMediator
{
    public async Task<TResponse> Publish<TResponse>(IRequest<TResponse> request)
    {
        using var scope = scopeFactory.CreateScope();

        var handlerType = typeof(IHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var handler = scope.ServiceProvider.GetService(handlerType);
        if (handler is null)
            throw new Exception($"Handler {handlerType} not found");

        var method = handlerType.GetMethod("Handle");
        if (method is null)
            throw new Exception($"Handler {handlerType} does not have a Handle method");

        var task = (Task)method.Invoke(handler, [request])!;

        await task.ConfigureAwait(false);

        var resultProperty = task.GetType().GetProperty("Result");
        if (resultProperty is null)
            throw new Exception("Handle did not return a result");

        return (TResponse)resultProperty.GetValue(task)!;
    }
}