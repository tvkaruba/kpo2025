using AppWithDependencyInjection.Models;
using AppWithDependencyInjection.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace AppWithDependencyInjection.Services;

public sealed class ReportService(IReportSaver reportSaver, IReportSender reportSender)
{
    public void ProcessReport(Report report)
    {
        reportSaver.SaveReport(report);
        reportSender.SendReport(report);
    }
}
