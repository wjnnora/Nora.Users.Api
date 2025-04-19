using MediatR;

namespace Nora.Users.Api.Extensions;

public static class ServiceCollections
{
    public static IServiceCollection AddMediatR<T1>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T1));
        return services;
    }

    public static IServiceCollection AddMediatR<T1, T2>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T1), typeof(T2));        
        return services;
    }

    public static IServiceCollection AddAutoMapper<T1>(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(T1).Assembly);

        return services;
    }
}