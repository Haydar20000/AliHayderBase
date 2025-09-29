using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AliHayderBase.Web.Client;
using AliHayderBase.Shared.Core.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

var apiBaseUrl = "https://localhost:7090";

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

// IAuthService
builder.Services.AddScoped<WebAuthService>();
builder.Services.AddScoped<IAuthService>(sp => sp.GetRequiredService<WebAuthService>());

// AuthenticationStateProvider
builder.Services.AddScoped<AuthenticationStateProvider, WebAuthProvider>();

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


await builder.Build().RunAsync();