using AppWithServiceLocator.Models;
using AppWithServiceLocator.Services.Abstractions;

namespace AppWithServiceLocator.Services;

internal sealed class EmailReportSender(string email) : IReportSender
{
    public void SendReport(Report report)
    {
        Console.WriteLine($"Отправка отчета на email: {email}");
    }
}
