using Microsoft.Extensions.DependencyInjection;

namespace CalCalc.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<IDummyService, DummyService>();
        
        return services;
    }
}