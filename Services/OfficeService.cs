using Newtonsoft.Json;

public class OfficeService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _contextAccessor;

    public OfficeService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
        var httphelpernew = new httpHelpers();
        _httpClient = httphelpernew.HttpHelper(httpClient, contextAccessor);
    }

    public async Task<List<OfficeDto>> ListOfficesAsync()
    {
        var response = await _httpClient.GetAsync("api/office/list");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var offices = JsonConvert.DeserializeObject<List<OfficeDto>>(json); // Fixed: Use JsonConvert from Newtonsoft.Json
        return offices;
    }
}
