using System.Net.Http.Json;
using UniversalCarShop.UseCases.Reports;

namespace UniversalCarShop.Infrastructure.Reports;

internal sealed class ReportServerConnector : IReportServerConnector
{
    private readonly HttpClient _httpClient;

    public ReportServerConnector(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void SendEvent(ReportedEventDto reportedEventDto)
    {
        _httpClient.PostAsJsonAsync("/api/v1/report-event", reportedEventDto).Wait();
    }
}

