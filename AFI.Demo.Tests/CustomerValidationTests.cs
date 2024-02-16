using AFI.Demo.Features.Customers.Commands;
using AFI.Demo.Features.Customers.Validators;
using Bogus;
using Bogus.Extensions;
using FluentValidation.TestHelper;

namespace AFI.Demo.Tests;

public class CustomerValidationTests
{
    private readonly PostCustomerCommandValidator _postCustomerCommandValidator;

    public CustomerValidationTests()
    {
        _postCustomerCommandValidator = new PostCustomerCommandValidator();
    }

    private static Faker<PostCustomerCommand> GetPostCustomerCommandGenerator()
    {
        return new Faker<PostCustomerCommand>()
            .RuleFor(v => v.FirstName, f => f.Name.FirstName().ClampLength(3, 50))
            .RuleFor(v => v.Surname, f => f.Name.LastName().ClampLength(3, 50))
            .RuleFor(v => v.PolicyReference, f => "AA-123456")
            .RuleFor(v => v.DateOfBirth, f => f.Date.Past(18, new DateTime(2000, 01, 01)))
            .RuleFor(v => v.Email, f => "test@email.com");
    }

    [Fact]
    public void Test_Valid()
    {
        var command = GetPostCustomerCommandGenerator().Generate();

        var result = _postCustomerCommandValidator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Customer_FirstName_Is_Not_Null()
    {
        var command = GetPostCustomerCommandGenerator().Generate();
        command.FirstName = null;

        var result = _postCustomerCommandValidator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void Customer_FirstName_Length__Of_Less_Than_3_Is_Error()
    {
        var command = GetPostCustomerCommandGenerator().Generate();
        command.FirstName = "AB";

        var result = _postCustomerCommandValidator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void Customer_FirstName_Length__Of_3_Is_Valid()
    {
        var command = GetPostCustomerCommandGenerator().Generate();
        command.FirstName = "ABC";

        var result = _postCustomerCommandValidator.TestValidate(command);
        result.ShouldNotHaveAnyValidationErrors();
    }

    // etc...
}
