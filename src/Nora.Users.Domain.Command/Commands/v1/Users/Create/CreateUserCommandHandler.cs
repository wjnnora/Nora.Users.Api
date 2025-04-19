using AutoMapper;
using MediatR;
using Nora.Core.Database.Contracts;
using Nora.Core.Database.Contracts.Repositories;
using Nora.Users.Domain.Contracts.Repositories;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Domain.Command.Commands.v1.Users.Create;

public sealed class CreateUserCommandHandler(
    IUserRepository orderRepository,
    IUnitOfWork<ISqlContext> unitOfWork,
    IMapper mapper) : IRequestHandler<CreateUserCommand, Unit>
{
    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);        

        await orderRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}