using PortfolioApp.Common.BaseErrors;
using PortfolioApp.Domain.Enums;

namespace PortfolioApp.Domain.Common.BaseErrors;


public class GeneralError (string title, string message, StatusCode statusCode) : BaseError(title, message, statusCode);

