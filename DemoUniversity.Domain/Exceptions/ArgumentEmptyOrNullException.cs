namespace DemoUniversity.Domain.Exceptions;

public class ArgumentEmptyOrNullException : Exception
{
    public ArgumentEmptyOrNullException(string message) : base(message)
    {
        
    }
}