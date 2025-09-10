namespace MedicalCenterManagement.Domain.Messages;

public static class ErrorMessages
{
    public static string CannotBeEmpty(string field)
        => $"{field} cannot be empty";

    public static string HasMaxLength(string field, int length)
        => $"{field} must have a maximum of {length} characters";

    public static string NotFound(string field)
        => $"{field} cannot be found";
    
    public static string NotFound<T>()
        => $"{typeof(T).Name} cannot be found";
    
    public static string MustBeUnique(string field)
        => $"{field} must be unique";
}