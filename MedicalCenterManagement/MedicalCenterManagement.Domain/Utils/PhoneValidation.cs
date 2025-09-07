namespace MedicalCenterManagement.Domain.Utils;

public static class PhoneValidation
{
    public const string PhoneNumberRegex = @"/^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$/";
}