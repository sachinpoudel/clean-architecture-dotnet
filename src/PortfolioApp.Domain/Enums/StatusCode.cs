namespace PortfolioApp.Domain.Enums;

public enum StatusCode
{
    BadRequest = 400,
    NotFound = 404,
    Validation = 422,
    Conflict = 409,
    UnAuthorized = 401,
    Forbidden = 403,
    ServiceUnavailable = 503,
    Success = 200,
    Created = 201,
    InternalServerError = 500,
    BadGateway = 502
}