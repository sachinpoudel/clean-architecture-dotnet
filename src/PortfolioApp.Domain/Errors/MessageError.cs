using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Errors;


public static class MessageError // 
{
 public static  BaseError MessageNotFound(string messageId)
    {
        return BaseError.NotFound("Message Not Found", $"The message with ID {messageId} was not found.");
    }
    public static BaseError FailedToSendMessage(string userId)
    {
        return BaseError.BadRequest("Failed to Send Message", $"An error occurred while trying to send the message for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToGetMessages(string userId)
    {
        return BaseError.BadRequest("Failed to Get Messages", $"An error occurred while trying to retrieve messages for user with ID {userId}. Please try again.");
    }

    public static BaseError FailedToDeleteMessage(string messageId)
    {
        return BaseError.BadRequest("Failed to Delete Message", $"An error occurred while trying to delete the message with ID {messageId}. Please try again.");
    }
    public static BaseError FailedToUpdateMessage(string messageId)
    {
        return BaseError.BadRequest("Failed to Update Message", $"An error occurred while trying to update the message with ID {messageId}. Please try again.");
    }
    public static BaseError MessageNotBelongToUser(string userId)
    {
        return BaseError.NotFound("Message Not Belong To User", $"The message you are trying to access does not belong to the user with ID {userId}.");
    }
} 