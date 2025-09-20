namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface IPasswordHashService
{
    string HashPassword(string password);
}