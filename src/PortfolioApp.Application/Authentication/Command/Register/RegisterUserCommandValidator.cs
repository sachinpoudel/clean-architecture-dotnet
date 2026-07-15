using FluentValidation;

namespace PortfolioApp.Application.Users.Command.CreateUser;


public class ValidateCreateUserCommand : AbstractValidator<RegisterUserCommand>
{
    public ValidateCreateUserCommand()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email address is required.");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        // RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm password is required.");
        RuleFor(x => x.Bio).NotEmpty().WithMessage("Bio is required.");
        RuleFor(x => x.ProfilePicture).NotEmpty().WithMessage("Profile picture is required.");
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
        RuleFor(x => x.Headline).NotEmpty().WithMessage("Headline is required.");
    }
}