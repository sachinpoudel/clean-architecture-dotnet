using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Errors;


public static class SocialLinkError
{
    public static BaseError SocialLinkNotBelongToUser(string userId)
    {
        return BaseError.NotFound("Social Link Not Belong To User", $"The social link you are trying to access does not belong to the user with ID {userId}.");
    }
    public static BaseError SocialLinkNotFound(string socialLinkId)
    {
        return BaseError.NotFound("Social Link Not Found", $"The social link with ID {socialLinkId} was not found.");
    }
    public static BaseError FailedToGetSocialLinks(string userId)   
    {
        return BaseError.BadRequest("Failed to Get Social Links", $"An error occurred while trying to retrieve social links for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToAddSocialLink(string userId)
    {
        return BaseError.BadRequest("Failed to Add Social Link", $"An error occurred while trying to add the social link for user with ID {userId}. Please try again.");
    }
  
    public static BaseError FailedToUpdateSocialLink(string socialLinkId)
    {
        return BaseError.BadRequest("Failed to Update Social Link", $"An error occurred while trying to update the social link with ID {socialLinkId}. Please try again.");
    }
    public static BaseError FailedToDeleteSocialLink(string socialLinkId) 
    {
        return BaseError.BadRequest("Failed to Delete Social Link", $"An error occurred while trying to delete the social link with ID {socialLinkId}. Please try again.");
    }
 
    
}