using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AliHayderBase.Shared.Services;
using AliHayderBase.Web.Client;
using AliHayderBase.Shared.Core.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the AliHayderBase.Shared project
//builder.Services.AddSingleton<IFormFactor, FormFactor>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.RootComponents.Add<App>("#app");

// Read from config
//var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5127";
var apiBaseUrl = "https://localhost:7090";

// Register HttpClient for API calls
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Register your services
builder.Services.AddScoped<IAuthService, AuthService>();


await builder.Build().RunAsync();
