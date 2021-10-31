using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using FamilyManager2UI.WebClient;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models;


namespace FamilyManager2UI.Data {
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
        private readonly IJSRuntime _jsRuntime;
        private readonly IRestClient _restClient;
        private User _cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IRestClient restClient) {
            this._jsRuntime = jsRuntime;
            this._restClient = restClient;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
            var identity = new ClaimsIdentity();
            if (_cachedUser == null) {
                string userAsJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson)) {
                    User tmp = JsonSerializer.Deserialize<User>(userAsJson);
                    await ValidateLogin(tmp.Username, tmp.Password);
                }
            } else {
                identity = SetupClaimsForUser(_cachedUser);
            }
            
            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string username, string password) {
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("Please specify a username");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Please specify a password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try {
                User user = await _restClient.GetAsync<User>(username, password);
                identity = SetupClaimsForUser(user);
                string serializedData = JsonSerializer.Serialize(user);
                await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedData);
                _cachedUser = user;
            }
            catch (Exception e) {
                throw e;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public async Task ValidateRegister(string username, string password, string confirmationPassword) {
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("Please specify a username");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Please specify a password");
            if (string.IsNullOrWhiteSpace(confirmationPassword)) throw new Exception("Please confirm your password");
            
            if (!password.Equals(confirmationPassword))
                throw new Exception("Passwords do not match");

            User user = new User() {
                Username = username,
                Password = password,
                Role = Role.User
            };

            await _restClient.PostAsync(user);
        }

        public void Logout() {
            _cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        
        private ClaimsIdentity SetupClaimsForUser(User user) {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}