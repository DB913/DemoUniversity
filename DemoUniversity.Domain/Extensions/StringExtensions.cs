namespace DemoUniversity.Domain.Extensions;

public static class StringExtensions
{
    public static bool CheckStringLength(this string input, int minSize = 2, int maxSize = 60)
    {
        return input.Length >= minSize && input.Length <= maxSize;
    }
}