using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Errors;


public class ExperienceError
{
    public static BaseError ExperienceNotBelongToUser(string userId)
    {
        return BaseError.NotFound("Experience Not Belong To User", $"The experience you are trying to access does not belong to the user with ID {userId}.");
    }
    public static BaseError FailedToAddExperience(string userId)
    {
        return BaseError.BadRequest("Failed to Add Experience", $"An error occurred while trying to add the experience for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToUpdateExperience(string userId)
    {
        return BaseError.BadRequest("Failed to Update Experience", $"An error occurred while trying to update the experience for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToDeleteExperience(string userId)
    {
        return BaseError.BadRequest("Failed to Delete Experience", $"An error occurred while trying to delete the experience for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToGetExperience(string userId)
    {
        return BaseError.BadRequest("Failed to Get Experience", $"An error occurred while trying to retrieve the experience for user with ID {userId}. Please try again.");
    }
}