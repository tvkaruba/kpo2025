using AppWithPureDI.Models;

namespace AppWithPureDI.Services.Abstractions;

public interface IReportSaver
{
    void SaveReport(Report report);
}