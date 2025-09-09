namespace MedicalCenterManagement.Application.Common.Responses;

public class UnprocessableResponse<T> : ApiResponse<T> 
{
    public UnprocessableResponse(string message)
    {
        StatusCode = 422;
        IsSuccess = false;
        Message = message;
    }
}