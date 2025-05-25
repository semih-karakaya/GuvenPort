using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class DashboardService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _contextAccessor;

    public DashboardService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
        var httphelpernew = new httpHelpers();
        _httpClient = httphelpernew.HttpHelper(httpClient, contextAccessor);
    }

    public async Task<int> GetActiveCompaniesCountAsync()
    {
        var response = await _httpClient.GetAsync("api/office/total-active-companies");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var obj = JsonSerializer.Deserialize<JsonElement>(json);
        return obj.GetProperty("total_active_companies").GetInt32();
    }

    public async Task<int> GetActiveOfficesCountAsync()
    {
        var response = await _httpClient.GetAsync("api/office/total-active-workplaces");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var obj = JsonSerializer.Deserialize<JsonElement>(json);
        return obj.GetProperty("total_active_workplaces").GetInt32();
    }

}
