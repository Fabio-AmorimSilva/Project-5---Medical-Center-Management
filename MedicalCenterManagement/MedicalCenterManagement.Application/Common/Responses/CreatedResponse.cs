namespace MedicalCenterManagement.Application.Common.Responses;

public class CreatedResponse<T> : ApiResponse<T>
{
    public CreatedResponse(T data)
    {
        StatusCode = 201;
        IsSuccess = true;
        Data = data;
    }
}