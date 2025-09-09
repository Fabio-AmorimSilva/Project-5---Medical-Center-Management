namespace MedicalCenterManagement.Application.Common.Responses;

public class NoContentResponse : ApiResponse
{
    public NoContentResponse()
    {
        StatusCode = 204;
        IsSuccess = true;
    }
}