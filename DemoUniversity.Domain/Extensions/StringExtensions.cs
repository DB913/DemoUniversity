using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Extensions;

public static class StringExtensions
{
    public static void ValidateLength(this string input, int minSize = 2, int maxSize = 60)
    {
        if (input.Length < minSize || input.Length > maxSize)
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {minSize} до {maxSize} символов");
        }
    }
    
    public static void ValidateRange(this int input, int minValue = 16, int maxValue = 150)
    {
        if (input < minValue || input > maxValue)
        {
            throw new IncorrectRangeException(
                $"Допустимый диапозон принимаемых значений от {minValue} до {maxValue}");
        }
    }
}