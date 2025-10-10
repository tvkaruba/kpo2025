using AppWithPureDI.Models;
using AppWithPureDI.Services.Abstractions;

namespace AppWithPureDI.Services;

internal sealed class TextReportSaver : IReportSaver
{
    private readonly string _fileName;

    public TextReportSaver(string fileName)
    {
        _fileName = fileName;
    }

    public void SaveReport(Report report)
    {
        File.WriteAllText(_fileName, report.ToString());
    }
}