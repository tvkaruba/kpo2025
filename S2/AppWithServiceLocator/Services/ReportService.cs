using AppWithServiceLocator.Models;
using AppWithServiceLocator.Services.Abstractions;

namespace AppWithServiceLocator.Services;

public sealed class ReportService
{
    public void ProcessReport(Report report)
    {
        var reportSaver = ServiceLocator.GetService<IReportSaver>();
        var reportSender = ServiceLocator.GetService<IReportSender>();

        reportSaver?.SaveReport(report);
        reportSender?.SendReport(report);
    }
}