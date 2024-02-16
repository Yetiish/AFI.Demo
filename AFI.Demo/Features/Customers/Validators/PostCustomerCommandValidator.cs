using AFI.Demo.Features.Customers.Commands;
using FluentValidation;

namespace AFI.Demo.Features.Customers.Validators;

public class PostCustomerCommandValidator : AbstractValidator<PostCustomerCommand>
{
    public PostCustomerCommandValidator()
    {
        RuleFor(m => m).NotEmpty().WithMessage("Request input is empty");

        RuleFor(m => m.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);

        RuleFor(m => m.Surname).NotEmpty().MinimumLength(3).MaximumLength(50);

        RuleFor(m => m.PolicyReference)
            .NotEmpty()
            .Matches(@"^[A-Z]{2}-\d{6}$")
            .WithMessage("Policy reference must be in the format XX-999999");

        When(
            m => m.DateOfBirth.HasValue,
            () =>
            {
                RuleFor(m => m.DateOfBirth)
                    .LessThanOrEqualTo(DateTime.Today.AddYears(-18))
                    .WithMessage("Customer must be at least 18 years old");
            }
        );

        When(
            m => !string.IsNullOrEmpty(m.Email),
            () =>
            {
                RuleFor(m => m.Email)
                    .Matches(@"^[a-zA-Z0-9]{4,}@{1}[a-zA-Z0-9]{2,}\.(com|co\.uk)$")
                    .WithMessage("Email is in an incorrect format");
            }
        );

        When(
            m => !m.DateOfBirth.HasValue,
            () =>
            {
                RuleFor(m => m.Email)
                    .NotEmpty()
                    .WithMessage("One of Email or Date of Birth is required");
            }
        );
    }
}
