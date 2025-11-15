using ReportServer.Client;
using UniversalCarShop.Reports;

namespace UniversalCarShop.Reports;

public sealed class ReportServiceClient
{
    private readonly ReportServerClient _reportServerClient;

    public ReportServiceClient(ReportServerClient reportServerClient)
    {
        _reportServerClient = reportServerClient;
    }

    public async Task<IEnumerable<Report>> GetReportsAsync()
    {
        var externalReports = await _reportServerClient.GetReportsAsync();
        return externalReports.Select(er => new Report(er.Title, er.Contents));
    }

    public async Task<Report?> GetReportAsync(string id)
    {
        var externalReport = await _reportServerClient.GetReportAsync(id);
        return externalReport != null ? new Report(externalReport.Title, externalReport.Contents) : null;
    }
}