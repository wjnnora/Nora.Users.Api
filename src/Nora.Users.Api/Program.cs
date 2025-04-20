using Microsoft.EntityFrameworkCore;
using Nora.Core.Database.Configurations;
using Nora.Core.Database.Postgres.EntityFramework.Configurations;
using Nora.Users.Domain.Command.Commands.v1.Users.Create;
using Nora.Users.Domain.Command.Mappers;
using Nora.Users.Domain.Query.Queries.v1.Users.GetById;
using Nora.Users.Infrastructure.Database.EntityFramework;
using Nora.Users.Infrastructure.Database.EntityFramework.Repositories;
using Nora.Users.Api.Extensions;
using Nora.Users.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR<CreateUserCommandHandler, GetUserByIdQueryHandler>();
builder.Services.AddEntityFramework<AppDbContext>(builder.Configuration);
builder.Services.AddRepositories<UserRepository>();
builder.Services.AddAutoMapper<UserProfile>();

var app = builder.Build();

if (builder.Configuration.GetSection("ExecuteMigration").Get<bool>())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
