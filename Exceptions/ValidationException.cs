namespace Week3Task1.Exceptions;

public class ValidationException : AppException
{
    public ValidationException(string message) : base(message, 400) { }
}