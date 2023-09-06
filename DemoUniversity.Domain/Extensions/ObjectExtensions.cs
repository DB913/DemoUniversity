using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Extensions;

public static class ObjectExtensions
{
    public static void ValidateEmptyObject(this object input)
    {
        if (input == null)
        {
            throw new EmptyObjectException(
                "Передаваемый объект не может быть null");
        }
    }
}