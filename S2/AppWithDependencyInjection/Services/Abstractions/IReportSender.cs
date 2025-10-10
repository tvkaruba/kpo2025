using AppWithDependencyInjection.Models;

namespace AppWithDependencyInjection.Services.Abstractions;

public interface IReportSender
{
    void SendReport(Report report);
}
