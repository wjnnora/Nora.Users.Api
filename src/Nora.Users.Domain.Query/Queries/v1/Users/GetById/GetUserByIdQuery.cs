using MediatR;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Domain.Query.Queries.v1.Users.GetById;

public sealed class GetUserByIdQuery(int id) : IRequest<User>
{
    public int Id { get; set; } = id;
}