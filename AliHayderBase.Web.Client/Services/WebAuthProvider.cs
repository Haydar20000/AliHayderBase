using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class WebAuthProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        return Task.FromResult(new AuthenticationState(anonymous));
    }
}



// using System.Security.Claims;
// using System.Text.Json;
// using Blazored.LocalStorage;
// using Microsoft.AspNetCore.Components.Authorization;

// public class WebAuthProvider : AuthenticationStateProvider
// {
//     private readonly ILocalStorageService _localStorage;
//     private readonly WebAuthService _authService;

//     public WebAuthProvider(WebAuthService authService, ILocalStorageService localStorage)
//     {
//         _localStorage = localStorage;
//         _authService = authService;

//         _authService.OnLogin += async () =>
//     {
//         var token = await _localStorage.GetItemAsync<string>("token");
//         NotifyUserAuthentication(token);
//     };

//         _authService.OnLogout += () =>
//         {
//             NotifyUserLogout();
//         };

//     }
//     public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//     {
//         var token = await _localStorage.GetItemAsync<string>("token");

//         if (string.IsNullOrWhiteSpace(token))
//             return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

//         var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
//         var user = new ClaimsPrincipal(identity);

//         return new AuthenticationState(user);
//     }

//     public void NotifyUserAuthentication(string token)
//     {
//         var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
//         var user = new ClaimsPrincipal(identity);
//         NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
//     }

//     public void NotifyUserLogout()
//     {
//         var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
//         NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
//     }

//     private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
//     {
//         var payload = jwt.Split('.')[1];
//         var jsonBytes = Convert.FromBase64String(PadBase64(payload));
//         var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

//         return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
//     }

//     private string PadBase64(string base64)
//     {
//         switch (base64.Length % 4)
//         {
//             case 2: return base64 + "==";
//             case 3: return base64 + "=";
//             default: return base64;
//         }
//     }
// }



// // using System.Security.Claims;
// // using System.Text.Json;
// // using Blazored.LocalStorage;
// // using Microsoft.AspNetCore.Components.Authorization;

// // public class WebAuthProvider : AuthenticationStateProvider
// // {
// //     private readonly ILocalStorageService _localStorage;

// //     public WebAuthProvider(WebAuthService authService, ILocalStorageService localStorage)
// //     {
// //         _localStorage = localStorage;

// //         authService.OnLogin += NotifyUserAuthentication;
// //         authService.OnLogout += NotifyUserLogout;
// //     }

// //     public override async Task<AuthenticationState> GetAuthenticationStateAsync()
// //     {
// //         var token = await _localStorage.GetItemAsync<string>("token");

// //         if (string.IsNullOrEmpty(token))
// //         {
// //             var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
// //             return new AuthenticationState(anonymous);
// //         }

// //         var claims = ParseClaimsFromJwt(token);
// //         var identity = new ClaimsIdentity(claims, "jwt");
// //         var user = new ClaimsPrincipal(identity);

// //         return new AuthenticationState(user);
// //     }

// //     private void NotifyUserAuthentication()
// //     {
// //         NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
// //     }

// //     private void NotifyUserLogout()
// //     {
// //         NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
// //     }

// //     private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
// //     {
// //         var claims = new List<Claim>();
// //         var payload = jwt.Split('.')[1];
// //         var jsonBytes = ParseBase64WithoutPadding(payload);
// //         var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

// //         if (keyValuePairs is null)
// //             return claims;

// //         foreach (var kvp in keyValuePairs)
// //         {
// //             if (kvp.Value is JsonElement element && element.ValueKind == JsonValueKind.Array)
// //             {
// //                 foreach (var item in element.EnumerateArray())
// //                 {
// //                     claims.Add(new Claim(kvp.Key, item.ToString()));
// //                 }
// //             }
// //             else
// //             {
// //                 claims.Add(new Claim(kvp.Key, kvp.Value.ToString() ?? ""));
// //             }
// //         }

// //         return claims;
// //     }

// //     private byte[] ParseBase64WithoutPadding(string base64)
// //     {
// //         switch (base64.Length % 4)
// //         {
// //             case 2: base64 += "=="; break;
// //             case 3: base64 += "="; break;
// //         }
// //         return Convert.FromBase64String(base64);
// //     }
// // }