namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface ISmsService
{
    Task SendMessage(string phoneNumber, string message);
}