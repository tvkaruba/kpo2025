using AppWithServiceLocator.Models;

namespace AppWithServiceLocator.Services.Abstractions;

public interface IReportSaver
{
    void SaveReport(Report report);
}
