using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class AuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthenticationService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
        var httphelpernew = new httpHelpers();
        _httpClient = httphelpernew.HttpHelper(httpClient, contextAccessor);
    }

    public async Task<LoginResult?> LoginAsync(string Mail, string Password)
    {
        var requestData = new { Mail = Mail, Password = Password };
        var jsonContent = new StringContent(
           JsonSerializer.Serialize(requestData),
           Encoding.UTF8,
           "application/json"
       );

        
        var response = await _httpClient.PostAsync("api/auth/login", jsonContent);

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
