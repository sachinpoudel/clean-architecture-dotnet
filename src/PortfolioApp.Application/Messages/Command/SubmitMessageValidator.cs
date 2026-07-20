using FluentValidation;

namespace PortfolioApp.Application.Messages.Command;


public class SubmitMessageValidator: AbstractValidator<SubmitMessageCommand>
{
    public SubmitMessageValidator()
    {
        RuleFor(x => x.SenderName)
            .NotEmpty().WithMessage("Sender name is required.")
            .MaximumLength(100).WithMessage("Sender name must not exceed 100 characters.");

        RuleFor(x => x.SenderEmail)
            .NotEmpty().WithMessage("Sender email is required.")
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject is required.")
            .MaximumLength(200).WithMessage("Subject must not exceed 200 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MaximumLength(1000).WithMessage("Content must not exceed 1000 characters.");
    }
}