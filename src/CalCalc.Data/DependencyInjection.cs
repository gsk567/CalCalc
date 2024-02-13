using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalCalc.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EntityContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(EntityContext)), builder =>
            {
                builder.MigrationsAssembly(typeof(EntityContext).Assembly.FullName);
            });
        });
        
        return services;
    }
}