using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace GoldenBarbers.Client
{
    public class LocalAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_user));
        }

        public void MarkUserAsAuthenticated(string username)
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, username)
        }, "apiauth_type");

            _user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _user = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
        }
    }

}
