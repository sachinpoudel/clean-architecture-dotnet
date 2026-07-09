using PortfolioApp.Domain.Common.BaseErrors;
using PortfolioApp.Domain.Enums;

namespace PortfolioApp.Common.BaseErrors;


public abstract class BaseError(string title, string message, StatusCode statusCode)
{
    public string Title { get;} = title;
    public string Message { get; } = message;
    public StatusCode StatusCode { get; } = statusCode;


    public static BaseError None()
    {
        return new GeneralError(string.Empty, string.Empty, StatusCode.Success);
    }

    public static BaseError BadRequest(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.BadRequest);
    }
    public static BaseError NotFound(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.NotFound);
    }
   public static BaseError UnAuthorized(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.UnAuthorized);
    }
    public static BaseError Forbidden(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.Forbidden);
    }
    public static BaseError InternalServerError(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.InternalServerError);
    }
    public static BaseError Validation(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.Validation);
    }
    public static BaseError Conflict(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.Conflict);
    }
    public static BaseError ServiceUnavailable(string title, string message)
    {
        return new GeneralError(title, message, StatusCode.ServiceUnavailable);
    }

}