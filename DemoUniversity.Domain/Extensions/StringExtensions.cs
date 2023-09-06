using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Extensions;

public static class StringExtensions
{
    public static void ValidateLength(this string input, int minSize = 2, int maxSize = 60)
    {
        if (input==null)
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (input.Length < minSize || input.Length > maxSize)
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {minSize} до {maxSize} символов");
        }
    }
}