namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface ISmsService
{
    Task SendMessage(string toPhoneNumber, string message);
}