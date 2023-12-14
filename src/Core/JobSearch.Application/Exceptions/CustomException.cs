namespace JobSearch.Application.Exceptions;

public class CustomException : Exception
{
    public CustomException() : base("An unexpected error has occurred!")
    {
    }

    public CustomException(string? message) : base(message)
    {
    }

    public CustomException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}