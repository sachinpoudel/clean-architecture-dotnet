using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Errors;


public static class SkillError
{
    public static BaseError SkillNotBelongToUser(string userId)
    {
        return BaseError.NotFound("Skill Not Belong To User", $"The skill you are trying to access does not belong to the user with ID {userId}.");
    }
    public static BaseError SkillNotFound(string skillId)
    {
        return BaseError.NotFound("Skill Not Found", $"The skill with ID {skillId} was not found.");
    }
    public static BaseError FailedToGetSkills(string userId)
    {
        return BaseError.BadRequest("Failed to Get Skills", $"An error occurred while trying to retrieve skills for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToAddSkill(string userId)
    {
        return BaseError.BadRequest("Failed to Add Skill", $"An error occurred while trying to add the skill for user with ID {userId}. Please try again.");
    }
    public static BaseError FailedToUpdateSkill(string skillId)
    {
        return BaseError.BadRequest("Failed to Update Skill", $"An error occurred while trying to update the skill with ID {skillId}. Please try again.");
    }
    public static BaseError FailedToDeleteSkill(string skillId) 
    {
        return BaseError.BadRequest("Failed to Delete Skill", $"An error occurred while trying to delete the skill with ID {skillId}. Please try again.");
    }
 
    
}