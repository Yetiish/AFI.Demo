using AFI.Demo.Commands;
using FluentValidation;

namespace AFI.Demo.Validators;

public class PutUserCommandValidator : AbstractValidator<PutUserCommand>
{
    public PutUserCommandValidator()
    {
        RuleFor(m => m.Input).NotEmpty().WithMessage("Request input is empty");

        RuleFor(m => m.Input.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);

        RuleFor(m => m.Input.Surname).NotEmpty().MinimumLength(3).MaximumLength(50);

        RuleFor(m => m.Input.PolicyReference)
            .NotEmpty()
            .Matches(@"^[A-Z]{2}-\d{6}$")
            .WithMessage("Policy reference must be in the format XX-999999");

        When(
            m => m.Input.DateOfBirth.HasValue,
            () =>
            {
                RuleFor(m => m.Input.DateOfBirth)
                    .LessThanOrEqualTo(DateTime.Today.AddYears(-18))
                    .WithMessage("User must be at least 18 years old");
            }
        );

        When(
            m => !string.IsNullOrEmpty(m.Input.Email),
            () =>
            {
                RuleFor(m => m.Input.Email)
                    .Matches(@"^[a-zA-Z0-9]{4,}@{1}[a-zA-Z0-9]{2,}\.(com|co\.uk)$")
                    .WithMessage("Email is in an incorrect format");
            }
        );

        When(
            m => !m.Input.DateOfBirth.HasValue,
            () =>
            {
                RuleFor(m => m.Input.Email)
                    .NotEmpty()
                    .WithMessage("One of Email or Date of Birth is required");
            }
        );
    }
}
