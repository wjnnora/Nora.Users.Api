using MediatR;

namespace Nora.Users.Domain.Command.Commands.v1.Users.Create;

public sealed class CreateUserCommand : IRequest<Unit>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public CreateUserAddressCommand Address { get; set; }

}