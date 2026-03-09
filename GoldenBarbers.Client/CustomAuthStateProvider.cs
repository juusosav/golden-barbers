using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using System.Net.Http.Json;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _http;

    public CustomAuthStateProvider(HttpClient http)
    {
        _http = http;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        UserInfo? user = null;

        try
        {
            user = await _http.GetFromJsonAsync<UserInfo>("api/account/user");
        }
        catch
        {
            // Could be 401, return anonymous
        }

        if (user == null || string.IsNullOrEmpty(user.Id) || string.IsNullOrEmpty(user.Email))
        {
            // Not logged in → return empty identity
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var claims = new List<Claim>();

        // Add role claims safely
        if (user.Roles != null)
        {
            foreach (var role in user.Roles.Where(r => !string.IsNullOrEmpty(r)))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
        claims.Add(new Claim(ClaimTypes.Name, user.Email));

        var identity = new ClaimsIdentity(claims, "apiauth_type");
        var principal = new ClaimsPrincipal(identity);

        return new AuthenticationState(principal);
    }

    private class UserInfo
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string[]? Roles { get; set; }
    }
}