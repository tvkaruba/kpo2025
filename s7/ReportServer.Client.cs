using System.Net.Http.Json;
using System.Text.Json;

namespace ReportServer.Client;

public class Report
{
    public string Title { get; set; } = string.Empty;
    public string Contents { get; set; } = string.Empty;
}

public class ReportServerClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ReportServerClient(string baseUrl)
    {
        _baseUrl = baseUrl.TrimEnd('/');
        _httpClient = new HttpClient();
    }

    public ReportServerClient(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl.TrimEnd('/');
    }

    public async Task<(Guid Id, string ViewUrl)> StoreReportAsync(Report report)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/reports", report);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<StoreReportResponse>();
        if (result == null)
            throw new InvalidOperationException("Failed to parse the server response");

        return (result.Id, result.ViewUrl);
    }

    public async Task<string> GetReportHtmlAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/reports/{id}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetLastReportHtmlAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/reports/last");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<IEnumerable<Report>> GetReportsAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/reports");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<Report>>() ?? [];
    }

    public async Task<Report?> GetReportAsync(string id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/reports/{id}");
        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<Report>();
    }

    private class StoreReportResponse
    {
        public Guid Id { get; set; }
        public string ViewUrl { get; set; } = string.Empty;
    }
}