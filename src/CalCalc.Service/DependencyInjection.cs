using CalCalc.Common.Contracts;
using CalCalc.Service.Foods.Services;
using CalCalc.Service.Identity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalCalc.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddScoped<IFoodService, FoodService>();

        return services;
    }
}