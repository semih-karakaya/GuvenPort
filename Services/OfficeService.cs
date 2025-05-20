using Newtonsoft.Json;

public class OfficeService
{
    private readonly HttpClient _httpClient;

    public OfficeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
