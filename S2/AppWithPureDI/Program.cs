using AppWithPureDI.Models;
using AppWithPureDI.Services;

var reportSaver = new TextReportSaver("report.txt");
var reportSender = new EmailReportSender("example@example.com");

var reportService = new ReportService(reportSaver, reportSender);

var report = new Report(
    Title: "Отчет",
    Date: DateOnly.FromDateTime(DateTime.Now),
    Time: TimeOnly.FromDateTime(DateTime.Now),
    CarsSold: 100,
    MotorcyclesSold: 50
);

reportService.ProcessReport(report);

Console.WriteLine("Report processed successfully");
