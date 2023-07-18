using System;

namespace DemoUniversity.Exceptions;

public class IncorrectStringLengthException : Exception
{
    public IncorrectStringLengthException(string message)
        : base(message) { }
}