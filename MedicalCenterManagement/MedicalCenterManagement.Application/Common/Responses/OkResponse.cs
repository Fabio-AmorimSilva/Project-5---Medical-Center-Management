namespace MedicalCenterManagement.Application.Common.Responses;

public class OkResponse<T> : ApiResponse<T>
{
    public OkResponse(T data)
    {
        StatusCode = 200;
        IsSuccess = true;
        Data = data;
    }
}