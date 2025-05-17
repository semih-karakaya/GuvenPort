using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class AuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResult?> LoginAsync(string Mail, string Password)
    {
        var requestBody = new { Mail, Password };
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", requestBody);
        if (!response.IsSuccessStatusCode)
            return null;

        var responseString = await response.Content.ReadAsStringAsync();
        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseString);

        if (loginResponse == null)
            return null;

        return new LoginResult
        {
            Token = loginResponse.Token,
            IsDoctor = loginResponse.IsDoctor,
            Name = loginResponse.Name
        };
    }

    private class LoginResponse
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
        [JsonPropertyName("isDoctor")]
        public bool IsDoctor { get; set; }
        [JsonPropertyName("name")]

        public string? Name { get; set; }
    }
}

public class LoginResult
{
    public string? Token { get; set; }
    public bool IsDoctor { get; set; }
    public string? Name { get; set; }
}
