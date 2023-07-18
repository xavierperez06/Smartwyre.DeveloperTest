using System.Net;

namespace Smartwyre.DeveloperTest.Core.Exceptions;

public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.InternalServerError;
    public string ErrorType { get; private set; }

    public BaseException(string message, string errorType, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
        ErrorType = errorType;
    }

    public BaseException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public BaseException(string message) : base(message)
    {
    }
}
