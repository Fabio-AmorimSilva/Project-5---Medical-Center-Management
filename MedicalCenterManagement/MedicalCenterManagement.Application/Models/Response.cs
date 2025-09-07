namespace MedicalCenterManagement.Application.Models;

public class Response
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    protected Response()
    {
    }

    public static Response Success()
        => new()
        {
            IsSuccess = true
        };

    public static Response Error(string message)
        => new()
        {
            IsSuccess = false,
            Message = message
        };
}

public class Response<T> : Response
{
    public T? Data { get; set; }

    public static Response<T> Success(T data)
        => new()
        {
            IsSuccess = true,
            Data = data
        };

    public new static Response<T> Error(string message)
        => new()
        {
            IsSuccess = false,
            Message = message
        };
}