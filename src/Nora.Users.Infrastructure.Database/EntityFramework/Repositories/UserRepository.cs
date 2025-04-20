using Microsoft.EntityFrameworkCore;
using Nora.Core.Database.Postgres.EntityFramework;
using Nora.Users.Domain.Contracts.Repositories;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Infrastructure.Database.EntityFramework.Repositories;

public sealed class UserRepository(AppDbContext context) : AbstractRepository<User, int>(context), IUserRepository
{
    public override Task<User> GetByIdAsync(int id)
    {
        return DbSet
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}