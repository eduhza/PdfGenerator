using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases;

public static class UseCasesRegistration
{
    public static IServiceCollection RegisterUseCases(this IServiceCollection services)
    {
        services.AddScoped<GenerateInvoicePdf>();

        return services;
    }
}
