using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Errors;


public static class EducationError
{
    public static BaseError EducationNotBelongToUser(string userId)
    {
        return BaseError.NotFound("Education Not Belong To User", $"The education you are trying to access does not belong to the user with ID {userId}.");
    }
    public static BaseError FailedToAddEducation(string userId)
    {
        return BaseError.BadRequest("Failed to Add Education", $"An error occurred while trying to add the education for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToUpdateEducation(string userId)
    {
        return BaseError.BadRequest("Failed to Update Education", $"An error occurred while trying to update the education for user with ID {userId}. Please try again.");
    }
    public static BaseError GetAllEducationsFailed(string userId)
    {
        return BaseError.BadRequest("Failed to Get All Educations", $"An error occurred while trying to retrieve all educations for user with ID {userId}. Please try again.");
    }
}

