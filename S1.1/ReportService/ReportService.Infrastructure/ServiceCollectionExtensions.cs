using Microsoft.Extensions.DependencyInjection;
using ReportService.Infrastructure.Repositories;
using ReportService.UseCases.ReportedEvents;
using ReportService.UseCases.ReportRendering;

namespace ReportService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ReportedEventRepository>();
        services.AddSingleton<IReportedEventServiceRepository>(sp => sp.GetRequiredService<ReportedEventRepository>());
        services.AddSingleton<IReportRenderingServiceRepository>(sp => sp.GetRequiredService<ReportedEventRepository>());

        return services;
    }
}
