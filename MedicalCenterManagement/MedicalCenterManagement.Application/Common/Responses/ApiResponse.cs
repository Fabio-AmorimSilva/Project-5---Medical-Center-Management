namespace MedicalCenterManagement.Application.Common.Responses;

public class ApiResponse<T> : Response<T>
{
    public int StatusCode { get; set; }
}

public class ApiResponse : Response
{
    public int StatusCode { get; set; }
}