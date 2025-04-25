using FluentValidation;

namespace Nora.Users.Domain.Command.Commands.v1.Users.Create;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(r => r.FirstName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(r => r.LastName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(r => r.Address)
            .NotNull()
            .SetValidator(new CreateUserAddressCommandValidator());
    }
}