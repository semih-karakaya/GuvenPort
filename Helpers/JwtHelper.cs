using System.IdentityModel.Tokens.Jwt;
using System.Linq;

public static class JwtHelper
{
    public static string? GetUserNameFromToken(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
      
        return token.Claims.FirstOrDefault(c => c.Type == "name")?.Value
            ?? token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
    }
}
