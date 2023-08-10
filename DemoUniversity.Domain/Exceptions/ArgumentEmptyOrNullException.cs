namespace DemoUniversity.Domain.Exceptions;

public class ArgumentEmptyOrNullException : NullReferenceException
{
    public ArgumentEmptyOrNullException(string message) : base(message)
    {
        
    }
}