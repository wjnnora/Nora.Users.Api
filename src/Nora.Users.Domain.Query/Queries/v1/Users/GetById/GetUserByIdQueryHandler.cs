using MediatR;
using Nora.Users.Domain.Contracts.Repositories;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Domain.Query.Queries.v1.Users.GetById;

public sealed class GetUserByIdQueryHandler(IUserRepository orderRepository) : IRequestHandler<GetUserByIdQuery, User>
{
    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        => await orderRepository.GetByIdAsync(request.Id);
}