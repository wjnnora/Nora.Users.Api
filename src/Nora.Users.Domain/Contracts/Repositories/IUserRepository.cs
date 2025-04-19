using Nora.Core.Domain.Contracts.Repositories;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Domain.Contracts.Repositories;

public interface IUserRepository : IRepository<User, int>;