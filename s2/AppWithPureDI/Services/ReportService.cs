using AppWithPureDI.Models;
using AppWithPureDI.Services.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppWithPureDI.Services;

public sealed class ReportService
{
    private readonly IReportSaver _reportSaver;

    private readonly IReportSender _reportSender;

    public ReportService(IReportSaver reportSaver, IReportSender reportSender)
    {
        _reportSaver = reportSaver;
        _reportSender = reportSender;
    }

    public void ProcessReport(Report report)
    {
        _reportSaver.SaveReport(report);
        _reportSender.SendReport(report);
    }
}