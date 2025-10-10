using AppWithDependencyInjection.Models;
using AppWithDependencyInjection.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace AppWithDependencyInjection.Services;

internal sealed class EmailReportSender(string email) : IReportSender
{
    public void SendReport(Report report)
    {
        Console.WriteLine($"Отправка отчета на email: {email}");
    }
}
