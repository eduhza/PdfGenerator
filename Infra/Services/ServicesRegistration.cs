using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;

namespace Infra.Services;

public static class ServicesRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IPdfService, PdfService>();

        return services;
    }
}
