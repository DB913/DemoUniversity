using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Extensions;

public static class IntExtensions
{
    public static bool CheckRange(this int input, int minValue = 16, int maxValue = 150)
    {
        return input >= minValue && input <= maxValue;

        // throw new IncorrectRangeException(
        //     $"Допустимый диапозон принимаемых значений от {minValue} до {maxValue}")
        // ;
    }
}