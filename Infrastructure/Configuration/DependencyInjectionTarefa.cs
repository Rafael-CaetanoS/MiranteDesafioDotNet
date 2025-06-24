using Domain.Repository;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class DependencyInjectionTarefa
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TarefaContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ITarefaRepository, TarefaRepository>();

        return services;
    }
}
