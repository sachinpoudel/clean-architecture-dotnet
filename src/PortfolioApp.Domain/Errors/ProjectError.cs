using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Errors;


public static class ProjectErrors
{
    public static BaseError ProjectNotBelongToUser(string userId)
    {
        return BaseError.NotFound("Project Not Belong To User", $"The project you are trying to access does not belong to the user with ID {userId}.");
    }
    public static BaseError ProjectNotFound(string projectId)
    {
        return BaseError.NotFound("Project Not Found", $"The project with ID {projectId} was not found.");
    }
    public static BaseError FailedToGetProjects(string userId)
    {
        return BaseError.BadRequest("Failed to Get Projects", $"An error occurred while trying to retrieve projects for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToAddProject(string userId)
    {
        return BaseError.BadRequest("Failed to Add Project", $"An error occurred while trying to add the project for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToUpdateProject(string projectId)
    {
        return BaseError.BadRequest("Failed to Update Project", $"An error occurred while trying to update the project with ID {projectId}. Please try again.");
    }
    public static BaseError FailedToDeleteProject(string projectId)
    {
        return BaseError.BadRequest("Failed to Delete Project", $"An error occurred while trying to delete the project with ID {projectId}. Please try again.");
    }
}