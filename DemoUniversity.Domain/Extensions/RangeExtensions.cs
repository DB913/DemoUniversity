using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Extensions;

public static class RangeExtensions
{
    public static void ValidateRange(this int input, int minValue = 16, int maxValue = 150)
    {
        if (input == 0)
        {
            throw new NullReferenceException("Значение не может равным 0");
        }

        if (input < minValue || input > maxValue)
        {
            throw new IncorrectRangeException(
                $"Допустимый диапозон принимаемых значений от {minValue} до {maxValue}");
        }
    }
}