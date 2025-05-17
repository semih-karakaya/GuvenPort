using System.IdentityModel.Tokens.Jwt;
using System.Linq;

public static class JwtHelper
{
    public static string? GetUserNameFromToken(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
        // "name" veya "unique_name" claim'ini kullanabilirsin, backend'e göre de?i?ir
        return token.Claims.FirstOrDefault(c => c.Type == "name")?.Value
            ?? token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
    }
}
