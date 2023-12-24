namespace JobSearch.Application.Exceptions;

public class CustomException : Exception
{
    public CustomException() : base("Beklenmeyen bir hata oluştu!")
    {
    }

    public CustomException(string? message) : base(message)
    {
    }

    public CustomException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}