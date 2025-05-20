// Services/AccidentService.cs
using System.Net.Http.Json;
using Models.DTOs;

public class AccidentService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://your-backend-api-url/api/accidents";

    public AccidentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AccidentDto>> GetAllAsync()
        => await _httpClient.GetFromJsonAsync<List<AccidentDto>>(ApiUrl);

    public async Task<AccidentDto> GetByIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<AccidentDto>($"{ApiUrl}/{id}");

    public async Task CreateAsync(AccidentDto accident)
        => await _httpClient.PostAsJsonAsync(ApiUrl, accident);

    public async Task UpdateAsync(AccidentDto accident)
        => await _httpClient.PutAsJsonAsync($"{ApiUrl}/{accident.Id}", accident);

    public async Task DeleteAsync(int id)
        => await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
}
