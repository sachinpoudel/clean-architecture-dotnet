using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Errors;


public static class UserError
{
    public static BaseError UserNotFound(string userId)
    {
        return BaseError.NotFound("User Not Found", $"The user with ID {userId} was not found.");
    }

    public static BaseError UserAlreadyExists(string email)
    {
        return BaseError.Conflict("User Already Exists", $"A user with the email {email} already exists.");
    }

    public static BaseError FailedToGetUser(string userId)
    {
        return BaseError.BadRequest("Failed to Get User", $"An error occurred while trying to retrieve the user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToUpdateUser(string userId)
    {
        return BaseError.BadRequest("Failed to Update User", $"An error occurred while trying to update the user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToDeleteUser(string userId)
    {
        return BaseError.BadRequest("Failed to Delete User", $"An error occurred while trying to delete the user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToCreateUser(string email)
    {
        return BaseError.BadRequest("Failed to Create User", $"An error occurred while trying to create a user with the email {email}. Please try again.");
    }
    public static BaseError LoginError(string email)
    {
        return BaseError.UnAuthorized("Login Error", $"An error occurred while trying to log in with the email {email}. Please check your credentials and try again.");
    }
    public static BaseError RegisterationError(string email)
    {
        return BaseError.BadRequest("Registration Error", $"An error occurred while trying to register with the email {email}. Please check your information and try again.");
    }
    public static BaseError IsAlreadyAdmin(string userId)
    {
        return BaseError.BadRequest("User Is Already Admin", $"The user with ID {userId} is already an admin.");
    }
    public static BaseError IsNotAdmin(string userId)
    {
        return BaseError.BadRequest("User Is Not Admin", $"The user with ID {userId} is not an admin.");
    }
    public static BaseError FailedToAssignRole(string userId, string role)
    {
        return BaseError.BadRequest("Failed to Assign Role", $"An error occurred while trying to assign the role {role} to the user with ID {userId}. Please try again.");
    }
    public static BaseError InvalidUserName(string userName)
    {
        return BaseError.BadRequest("Invalid User Name", $"The user name {userName} is invalid. Please provide a valid user name.");
    }
}