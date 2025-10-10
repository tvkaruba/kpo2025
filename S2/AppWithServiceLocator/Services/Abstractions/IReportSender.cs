using AppWithServiceLocator.Models;

namespace AppWithServiceLocator.Services.Abstractions;

public interface IReportSender
{
    void SendReport(Report report);
}
