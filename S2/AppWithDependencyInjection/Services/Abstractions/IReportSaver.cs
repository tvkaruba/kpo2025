using AppWithDependencyInjection.Models;

namespace AppWithDependencyInjection.Services.Abstractions;

public interface IReportSaver
{
    void SaveReport(Report report);
}
