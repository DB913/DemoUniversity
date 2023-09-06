using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Extensions;

public static class StringExtensions
{
    public static bool CheckStringLength(this string input, int minSize = 2, int maxSize = 60)
    {
        return input.Length >= minSize && input.Length <= maxSize;
        
        // throw new IncorrectStringLengthException($"Длина должна быть от {minSize} до {maxSize} символов");
        // if (input==null)
        // {
            // throw new NullReferenceException(
            //      "Передаваемое значение не может быть null");
        // }
    }
}