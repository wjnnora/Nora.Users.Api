using FluentValidation;

namespace Nora.Users.Domain.Command.Commands.v1.Users.Create;

public sealed class CreateUserAddressCommandValidator : AbstractValidator<CreateUserAddressCommand>
{
    public CreateUserAddressCommandValidator()
    {
        RuleFor(r => r.Street)
            .NotNull()
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(r => r.City)
            .NotNull()
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(r => r.State)
            .NotNull()
            .NotEmpty()
            .MaximumLength(2);

        RuleFor(r => r.ZipCode)
            .NotNull()
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(r => r.Country)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);
    }
}