using AppWithPureDI.Models;

namespace AppWithPureDI.Services.Abstractions;

public interface IReportSender
{
    void SendReport(Report report);
}