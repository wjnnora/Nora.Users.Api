using AutoMapper;
using Nora.Users.Domain.Command.Commands.v1.Users.Create;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Domain.Command.Mappers;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<CreateUserAddressCommand, Address>();            
    }
}