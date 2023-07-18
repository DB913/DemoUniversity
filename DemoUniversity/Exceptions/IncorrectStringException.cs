using System;

namespace DemoUniversity.Exceptions;

public class IncorrectStringException : ArgumentException
{
    public string PhoneNumber { get;}

    public IncorrectStringException(string message, string phoneNumber)
        : base(message)
    {
        PhoneNumber = phoneNumber;
    }
}