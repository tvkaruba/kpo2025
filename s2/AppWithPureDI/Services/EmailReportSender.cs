using AppWithPureDI.Models;
using AppWithPureDI.Services.Abstractions;

namespace AppWithPureDI.Services;

internal sealed class EmailReportSender : IReportSender
{
    private readonly string _email;

    public EmailReportSender(string email)
    {
        _email = email;
    }

    public void SendReport(Report report)
    {
        Console.WriteLine($"Отправка отчета на email: {_email}");
    }
}